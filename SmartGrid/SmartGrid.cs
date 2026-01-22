using C1.Excel;
using C1.Win.Command;
using C1.Win.FlexGrid;
using C1.Win.SuperTooltip;
//using GrapeCity.Documents.DX.Direct2D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SmartGrid
{
    public partial class SmartGrid : C1FlexGrid
    {
        // Конструктор
        public SmartGrid()
        {
            //var launch = System.Diagnostics.Debugger.Launch();
            InitializeComponent();
            this.Cols[0].Width = 30;
            this.Rows.Count = 10;
            this.Cols.Count = 10;
            this.KeyActionEnter = KeyActionEnum.MoveDown;
            this.DrawMode = DrawModeEnum.OwnerDraw;

            this.Styles.Normal.Border.Color = this.Styles.Fixed.Border.Color = Color.FromKnownColor(KnownColor.ControlDark);
            this.Styles.Fixed.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.Styles.Normal.Margins = new System.Drawing.Printing.Margins(1, 1, 1, 1);

            // фиксируем выделение строки при наведении в стиле Bookkeep
            this.SelectionMode = SelectionModeEnum.Row;
            this.Styles.Highlight.BackColor = Color.FromKnownColor(KnownColor.Info);
            this.Styles.Focus.BackColor = Color.FromKnownColor(KnownColor.Info);

            // выделение строк клавишами в стиле Bookkeep
            this.SelectedRows = new List<int>();
            this.Styles.Add("Selected", Styles.Normal);
            this.Styles["Selected"].ForeColor = Color.Red;
            this.KeyDown += SmartGrid_KeyDown;
            this.SelChange += SmartGrid_SelChange;
            this.MouseEnterCell += SmartGrid_MouseEnterCell;
            this.MouseLeaveCell += SmartGrid_MouseLeaveCell;
            this.AfterDataRefresh += SmartGrid_AfterDataRefresh;

            // подключение контекстного меню
            CreateContextMenu();

            // ресайз шрифта колесом мыши
            this.MouseWheel += FlexGrid_MouseWheel;

            // установка изначальной сортировки данных в гриде
            this.BeforeSort += SmartGrid_BeforeSort;
            this.AfterSort += SmartGrid_AfterSort;

            // форматирование футера в соответствии с форматом колонки
            this.OwnerDrawCell += SmartGrid_OwnerDrawCell;

            //временно для проверки
            AddHeader += SmartGrid_AddHeader;

            // построение иерархии
            this.MouseDown += TreeFlexGrid_MouseDown;
            this.MouseUp += TreeFlexGrid_MouseUp;
            this.MouseMove += TreeFlexGrid_MouseMove;
            //this.KeyDown += TreeFlexGrid_KeyDown;
            this.BeforeSort += TreeFlexGrid_BeforeSort;

            _dragToolTip = new ToolTip();
            _dragToolTip.ShowAlways = true;
        }


        //Вспомогательные свойства и методы для интеграции с Bookkeep и другими приложениями, а также корректного поведения различных функций
        // А.Кузнецов 23.01.2024
        #region Вспомогательные свойства и методы

        public bool IsEditing { get; set; } // Свойство для коррекции поведения клавиши Escape для SmartGrid'а на форме, унаследованной от TemplateFormMDI

        #endregion


        // Свойство Headers обеспечивает удобный механизм редактирования заголовков таблицы.
        // Радактирование происходит во всплывающем модальном диалоге.
        // Kатегория в списке свойств: Micros
        // </summary>
        // А.Кузнецов 15.06.2023
        #region  Headers / Свойство и методы

        private string[] _headers;

        /// <summary>
        /// Гибкое редактирование заголовков таблицы с автоматическим объединением соседних ячеек 
        /// с одинаковыми значениями по горизонтали и вертикали.
        /// </summary>
        [Category("Micros")]
        [Description("Helps to add merged multirow headers")]
        [Editor(typeof(HeadersUIEditor), typeof(UITypeEditor))]
        public string[] Headers
        {
            get { return _headers; }
            set
            {
                _headers = value;
                OnChangeHeaders();
            }
        }

        private void OnChangeHeaders()
        {
            //Если в редакторе заголовков внесены изменения, 
            //переносим их в редактируемую таблицу.
            if (Headers != null)
            {
                AllowMergingFixed = AllowMergingEnum.FixedOnly;

                string[][] cellHeaders = new string[Headers.Length][];

                for (int i = 0; i < Headers.Length; i++)
                {
                    if (Headers[i] == null)
                    {
                        Headers[i] = "..." + "\t";
                    }

                    string[] cells = Headers[i].Split('\t');
                    cellHeaders[i] = cells;
                    Rows[i].AllowMerging = true;

                    Cols.Count = cellHeaders[i].Length;

                    for (int j = 0; j < cellHeaders[i].Length; j++)
                    {
                        this[i, j] = cellHeaders[i][j];

                        Cols[j].AllowMerging = true;
                        Styles["Fixed"].TextAlign = TextAlignEnum.CenterCenter;
                    }
                }
            }
            else
            {
                //Если таблица заголовков в редакторе очищена, 
                //возвращаем редактируемую таблицу в исходное состояние.
                ClearHeaders();
            }
        }

        private void ClearHeaders()
        {
            AllowMergingFixed = AllowMergingEnum.None;

            for (int i = 0; i < Rows.Fixed; i++)
            {
                for (int j = 0; j < Cols.Count; j++)
                {
                    this[i, j] = "";
                }
            }
        }

        private void SmartGrid_GridChanged(object sender, GridChangedEventArgs e)
        {
            //Если в штатном Дизайнере добавлен столбец, 
            //переписываем Headers.
            if (e.GridChangedType == GridChangedTypeEnum.ColAdded)
            {
                if (Headers != null)
                {
                    RewriteHeaders();
                }
            }

            //Если в штатном Дизайнере удален столбец, 
            //переписываем Headers.
            if (e.GridChangedType == GridChangedTypeEnum.ColRemoved)
            {
                if (Headers != null)
                {
                    RewriteHeaders();
                }
            }

            //Если в штатном Дизайнере перемещен существующий столбец, 
            //переписываем Headers.
            if (e.GridChangedType == GridChangedTypeEnum.ColMoved)
            {
                if (Headers != null)
                {
                    RewriteHeaders();
                }
            }

            //Если уменьшено количество фиксированных строк заголовка,
            //очищаем высвобожденные строки таблицы
            if (e.GridChangedType == GridChangedTypeEnum.LayoutChanged)
            {
                if (Headers != null && Rows.Fixed < Headers.Length)
                {
                    for (int i = Headers.Length - 1; i > Rows.Fixed - 1; i--)
                    {
                        for (int j = 0; j < Cols.Count; j++)
                        {
                            this[i, j] = "";
                        }
                    }
                }
            }
        }

        private void RewriteHeaders()
        {
            string[] newHeaders = new string[Rows.Fixed];

            for (int i = 0; i < Rows.Fixed; i++)
            {
                for (int j = 0; j < Cols.Count; j++)
                {
                    var cell = this[i, j];
                    if (cell == null)
                    {
                        if (j == Cols.Count - 1)
                        {
                            newHeaders[i] += "...";
                            continue;
                        }

                        newHeaders[i] += "..." + "\t";
                        continue;
                    }

                    if (j == Cols.Count - 1)
                    {
                        newHeaders[i] += (string)cell;
                        continue;
                    }

                    newHeaders[i] += (string)cell + "\t";
                }
            }
            Headers = newHeaders;
        }


        #endregion

        // Реализация дефолтного функционала выделения строк клавишами в стиле Bookkeep:
        // [Insert] - выделение/снятие выделения строки с переходом на следующую строку
        // [Num +] - выделить все
        // [Num -] - отменить все выделение
        // [Num *] - инвертировать выделение
        // А.Кузнецов 15.09.2023
        #region Выделение строк клавишами [Insert], [Num +], [Num -], [Num *]

        public List<int> SelectedRows { get; set; }

        public List<Row> GetSelectedRows()
        {
            List<Row> res = new List<Row>();

            for (int i = 0; i < SelectedRows.Count; i++)
            {
                res.Add(Rows[SelectedRows[i]]);
            }

            if (res.Count == 0)
                res.Add(Rows[Row]);

            return res;
        }

        private void SmartGrid_SelChange(object sender, EventArgs e)
        {
            if (Row >= Rows.Fixed)
            {
                if( SelectedRows != null && SelectedRows.Contains(Row))
                {
                    Styles.Highlight.ForeColor = Color.Red;
                    Styles.Focus.ForeColor = Color.Red;
                }
                else
                {
                    Styles.Highlight.ForeColor = DefaultForeColor;
                    Styles.Focus.ForeColor = DefaultForeColor;
                }
            }
            if (Row >= Rows.Count - Footers.Descriptions.Count)
            {
                Row--;
            }
        }

        private void SmartGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Nodes.Count() == 0)
                this.KeyDown -= TreeFlexGrid_KeyDown;

            Styles.Focus.ForeColor = DefaultForeColor;

            // Выделение строки с курсором
            if (e.KeyCode == Keys.Insert)
            {
                int rw = Row;

                if (rw >= Rows.Fixed && rw < Rows.Count - Footers.Descriptions.Count)
                {
                    if (SelectedRows.Contains(rw))
                    {
                        Rows[rw].Style = Styles.Normal;
                        SelectedRows.Remove(rw);
                    }
                    else
                    {
                        Rows[rw].Style = Styles.NewRow;
                        Rows[rw].Style.ForeColor = Color.Red;
                        SelectedRows.Add(rw);
                    }

                    if (Row < Rows.Count - 1)
                        Row++;
                    else
                    {
                        Styles.Highlight.ForeColor = Color.Red;
                        Styles.Focus.ForeColor = Color.Red;
                    }

                    if (SelectedRows.Contains(Row))
                    {
                        Styles.Highlight.ForeColor = Color.Red;
                        Styles.Focus.ForeColor = Color.Red;

                    }
                    else
                    {
                        Styles.Highlight.ForeColor = DefaultForeColor;
                        Styles.Focus.ForeColor = DefaultForeColor;
                    }
                }

                if (SelectedRows.Count > 0)
                    _cmdExportSelectedToExcel.Visible = true;
                else
                    _cmdExportSelectedToExcel.Visible = false;
            }

            // Инверсия выделения
            if (e.KeyCode == Keys.Multiply)
            {
                e.SuppressKeyPress = true; // запрещаем клавише [NUM *] ввод символа в текстовое поле

                int rowsCount = Rows.Count - Rows.Fixed - Footers.Descriptions.Count;

                if (rowsCount > 0)
                {
                    for (int i = 0; i < rowsCount; i++)
                    {
                        int rw = i + Rows.Fixed;

                        if (SelectedRows.Contains(rw))
                        {
                            Rows[rw].Style = Styles.Normal;
                            SelectedRows.Remove(rw);
                        }
                        else
                        {
                            Rows[rw].Style = Styles.NewRow;
                            Rows[rw].Style.ForeColor = Color.Red;
                            SelectedRows.Add(rw);
                        }
                    }

                    if (SelectedRows.Contains(Row))
                    {
                        Styles.Highlight.ForeColor = Color.Red;
                        Styles.Focus.ForeColor = Color.Red;
                    }
                    else
                    {
                        Styles.Highlight.ForeColor = DefaultForeColor;
                        Styles.Focus.ForeColor = DefaultForeColor;
                    }
                }
            }

            // Отменить все выделение
            if (e.KeyCode == Keys.Subtract)
            {
                e.SuppressKeyPress = true; // запрещаем клавише [NUM -] ввод символа в текстовое поле

                int rowsCount = Rows.Count - Rows.Fixed - Footers.Descriptions.Count;

                if (rowsCount > 0)
                {
                    for (int i = 0; i < rowsCount; i++)
                    {
                        int rw = i + Rows.Fixed;

                        if (SelectedRows.Contains(rw))
                        {
                            Rows[rw].Style = Styles.Normal;
                            SelectedRows.Remove(rw);
                        }
                    }

                    Styles.Highlight.ForeColor = DefaultForeColor;
                    Styles.Focus.ForeColor = DefaultForeColor;
                }

                _cmdExportSelectedToExcel.Visible = false;
            }

            // Выделить все
            if (e.KeyCode == Keys.Add)
            {
                e.SuppressKeyPress = true; // запрещаем клавише [NUM *] ввод символа в текстовое поле

                int rowsCount = Rows.Count - Rows.Fixed - Footers.Descriptions.Count;

                if (rowsCount > 0)
                {
                    for (int i = 0; i < rowsCount; i++)
                    {
                        int rw = i + Rows.Fixed;

                        if (!SelectedRows.Contains(rw))
                        {
                            Rows[rw].Style = Styles.NewRow;
                            Rows[rw].Style.ForeColor = Color.Red;
                            SelectedRows.Add(rw);
                        }
                    }

                    Styles.Highlight.ForeColor = Color.Red;
                    Styles.Focus.ForeColor = Color.Red;
                }

                _cmdExportSelectedToExcel.Visible = true;
            }

            // Копировать ячейку Ctrl+C
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                SelectionMode = SelectionModeEnum.Cell;
                Copy();
                SelectionMode = SelectionModeEnum.Row;
            }
        }

        private void SmartGrid_AfterDataRefresh(object sender, ListChangedEventArgs e)
        {
            Styles.Highlight.ForeColor = DefaultForeColor;
            Styles.Focus.ForeColor = DefaultForeColor;
            if (SelectedRows != null) SelectedRows.Clear();
            _cmdExportSelectedToExcel.Visible = false;
        }

        public void UnselectAll()
        {
            foreach (var row in SelectedRows)
                Rows[row].Style = Styles.Normal;

            Styles.Highlight.ForeColor = DefaultForeColor;
            Styles.Focus.ForeColor = DefaultForeColor;
            SelectedRows.Clear();
            _cmdExportSelectedToExcel.Visible = false;
        }

        #endregion


        // Контекстное меню с дополнительными функциями для работы с компонентом SmartGrid:
        // - копирование отдельной ячейки в буфер;
        // - cуммирование значений выбранной колонки независимо от типа числовых значений;
        // - экспорт таблицы в Excel-файл.
        // А.Кузнецов 18.09.2023
        #region Контекстное меню / Свойства и методы

        /// <summary>
        /// Делегат для добавления дополнительных данных к экспортируемому Excel-файлу
        /// </summary>
        public event Action AddHeader;

        /// <summary>
        /// Предикат для валидации грида перед экспортом в Excel.
        /// </summary>
        public Predicate<SmartGrid> XLExportPredicate;

        /// <summary>
        /// Холдер для элементов контекстного меню
        /// </summary>
        private C1CommandHolder _commandHolder;

        /// <summary>
        /// Контекстное меню
        /// </summary>
        private C1ContextMenu _contextMenu;

        /// <summary>
        /// Пункт "Копировать ячейку" в контекстном меню (включен по умолчанию)
        /// </summary>
        private C1Command _cmdCopyCell;

        /// <summary>
        /// Пункт "Суммировать" в контекстном меню (включен по умолчанию)
        /// </summary>
        private C1Command _cmdSumCol;

        /// <summary>
        /// Пункт "Экспорт в Excel" в контекстном меню (включен по умолчанию)
        /// </summary>
        private C1Command _cmdExportToExcel;

        /// <summary>
        /// Пункт "Экспорт выделенного в Excel" в контекстном меню (по умолчанию выключен, активируется при выделении хотя бы одной строки)
        /// </summary>
        private C1Command _cmdExportSelectedToExcel;

        /// <summary>
        /// Пункт "Скрыть выделенную колонку" в контекстном меню
        /// </summary>
        private C1Command _cmdHideSelectedColumn;

        /// <summary>
        /// Пункт "Показать ранее скрытые колонки" в контекстном меню (по умолчанию выключен, активируется при скрытии первой колонки)
        /// </summary>
        private C1Command _cmdShowHiddenColumns;

        /// <summary>
        /// Сепаратор между пунктами меню
        /// </summary>
        private C1Command _cmdSeparator;

        /// <summary>
        /// Список скрытых колонок
        /// </summary>
        private List<int> _hiddenColumns = new List<int>();

        public void CreateContextMenu()
        {
            _commandHolder = C1CommandHolder.CreateCommandHolder(this);

            _cmdCopyCell = _commandHolder.CreateCommand();
            _cmdCopyCell.Text = "Копировать ячейку";
            _cmdCopyCell.Image = Properties.Resources.copy;
            _cmdCopyCell.Click += CopyCell_Click;

            _cmdSumCol = _commandHolder.CreateCommand();
            _cmdSumCol.Text = "Суммировать";
            _cmdSumCol.Image = Properties.Resources.sum;
            _cmdSumCol.Click += SumCol_Click;

            _cmdExportToExcel = _commandHolder.CreateCommand();
            _cmdExportToExcel.Text = "Экспорт в Excel";
            _cmdExportToExcel.Name = "ExportAll";
            _cmdExportToExcel.Image = Properties.Resources.excel;
            _cmdExportToExcel.Click += ExportToExcel_Click;

            _cmdExportSelectedToExcel = _commandHolder.CreateCommand();
            _cmdExportSelectedToExcel.Text = "Экспорт выделенного в Excel";
            _cmdExportSelectedToExcel.Name = "ExportSelected";
            _cmdExportSelectedToExcel.Image = Properties.Resources.excel;
            _cmdExportSelectedToExcel.Click += ExportToExcel_Click;
            _cmdExportSelectedToExcel.Visible = false;

            _cmdHideSelectedColumn = _commandHolder.CreateCommand();
            _cmdHideSelectedColumn.Text = "Скрыть выделенную колонку";
            _cmdHideSelectedColumn.Name = "HideSelectedColumn";
            _cmdHideSelectedColumn.Image = Properties.Resources.hide_column_25;
            _cmdHideSelectedColumn.Click += HideSelectedColumn_Click;

            _cmdShowHiddenColumns = _commandHolder.CreateCommand();
            _cmdShowHiddenColumns.Text = "Показать скрытые колонки";
            _cmdShowHiddenColumns.Name = "ShowHiddenColumns";
            _cmdShowHiddenColumns.Image = Properties.Resources.show_columns_25;
            _cmdShowHiddenColumns.Click += ShowHiddenColumns_Click;
            _cmdShowHiddenColumns.Visible = false;

            _cmdSeparator = _commandHolder.CreateCommand();
            _cmdSeparator.Text = "-";

            _contextMenu = _commandHolder.CreateCommand(typeof(C1ContextMenu)) as C1ContextMenu;
            //_contextMenu.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Silver;
            _contextMenu.CommandLinks.Add(new C1CommandLink(_cmdCopyCell));
            _contextMenu.CommandLinks.Add(new C1CommandLink(_cmdSumCol));
            _contextMenu.CommandLinks.Add(new C1CommandLink(_cmdExportToExcel));
            _contextMenu.CommandLinks.Add(new C1CommandLink(_cmdExportSelectedToExcel));
            _contextMenu.CommandLinks.Add(new C1CommandLink(_cmdSeparator));
            _contextMenu.CommandLinks.Add(new C1CommandLink(_cmdHideSelectedColumn));
            _contextMenu.CommandLinks.Add(new C1CommandLink(_cmdShowHiddenColumns));
            _commandHolder.SetC1ContextMenu(this, _contextMenu);
        }

        /// <summary>
        /// Добавляет новый пункт в контекстное меню экземпляра SmartGrid.
        /// </summary>
        /// <param name="name">Название пункта меню</param>
        /// <param name="image">Иконка пункта меню</param>
        /// <param name="handler">Делегат, представляющий метод, вызываемый по клику на пункте меню.</param>
        //
        // Note: Метод, записываемый в делегат, должен содержать стандартные аргументы (sender, e).
        //
        public void AddItemToContextMenu(string name, System.Drawing.Bitmap image, ClickEventHandler handler)
        {
            C1Command item = _commandHolder.CreateCommand();
            item.Text = name;
            item.Image = image;
            item.Click += handler;
            _contextMenu.CommandLinks.Add(new C1CommandLink(item));
        }

        /// <summary>
        /// Добавляет разделительную линию между пунктами контекстного меню.
        /// </summary>
        public void AddSeparator()
        {
            C1Command item = _commandHolder.CreateCommand();
            item.Text = "-";
            _contextMenu.CommandLinks.Add(new C1CommandLink(item));
        }

        /// <summary>
        /// Позволяет выборочно удалить из контекстного меню пункты по умолчанию
        /// </summary>
        /// <param name="removeCopyCell">Признак, если нужно удалить пункт "Копировать ячейку"</param>
        /// <param name="removeSumCol">Признак, если нужно ли удалить пункт "Суммировать"</param>
        /// <param name="removeExportToExcel">Признак, если нужно ли удалить пункт "Экспортировать в Excel"</param>
        /// <param name="removeHideColumn">Признак, если нужно удалить пункт "Скрыть выделенную колонку"</param>
        public void RemoveDefaultContextMenuItems(bool removeCopyCell = false, bool removeSumCol = false, bool removeExportToExcel = false,
                                                  bool removeHideColumn = false)
        {
            if (removeCopyCell)
            {
                object obj = _contextMenu.CommandLinks.Cast<C1CommandLink>().First(o => o.Command == _cmdCopyCell);
                _contextMenu.CommandLinks.Remove(obj);
            }

            if (removeSumCol)
            {
                object obj = _contextMenu.CommandLinks.Cast<C1CommandLink>().First(o => o.Command == _cmdSumCol);
                _contextMenu.CommandLinks.Remove(obj);
            }

            if (removeExportToExcel)
            {
                object obj = _contextMenu.CommandLinks.Cast<C1CommandLink>().First(o => o.Command == _cmdExportToExcel);
                _contextMenu.CommandLinks.Remove(obj);
            }

            if (removeHideColumn)
            {
                object obj = _contextMenu.CommandLinks.Cast<C1CommandLink>().First(o => o.Command == _cmdHideSelectedColumn);
                _contextMenu.CommandLinks.Remove(obj);
            }
        }

        // Копировать ячейку
        private void CopyCell_Click(object sender, EventArgs e)
        {
            SelectionMode = SelectionModeEnum.Cell;
            Copy();
            SelectionMode = SelectionModeEnum.Row;
        }

        // Суммировать значения выделенных ячеек по столбцу
        private void SumCol_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedRows();
            decimal sum = 0;

            for (int i = 0; i < sel.Count; i++)
            {
                var row = sel[i].Index;
                try
                {
                    sum += Convert.ToDecimal(this[row, Col]);
                }
                catch
                {
                    MessageBox.Show("Значения в данной колонке нельзя суммировать", "Суммировать колонку");
                    return;
                }
            }

            var sumForm = new SumForm();
            sumForm.Sum = sum.ToString();
            sumForm.ShowDialog();
        }

        //// Экспорт в Excel
        //public void ExportToExcel_Click(object sender, ClickEventArgs e)
        //{
        //    bool? isXLExport = XLExportPredicate?.Invoke(this);

        //    if (isXLExport.HasValue)
        //    {
        //        if (!isXLExport.Value)
        //            return;
        //    }

        //    C1XLBook book = new C1XLBook();

        //    XLSheet sheet = book.Sheets[0];
        //    sheet.Name = "List01";

        //    // Стиль фиксированных строк заголовка таблицы
        //    XLStyle styleFixed = new XLStyle(book)
        //    {
        //        Font = new Font("Tahoma", 9, FontStyle.Bold),
        //        ForeColor = Color.Black,
        //        BackColor = Color.AliceBlue,
        //        AlignHorz = XLAlignHorzEnum.Center,
        //        AlignVert = XLAlignVertEnum.Center,
        //        WordWrap = true
        //    };
        //    styleFixed.SetBorderStyle(XLLineStyleEnum.Thin);
        //    styleFixed.SetBorderColor(Color.FromKnownColor(KnownColor.ControlDark));

        //    // Стиль обычных строк
        //    XLStyle styleNormal = new XLStyle(book)
        //    {
        //        Font = new Font("Tahoma", 9, FontStyle.Regular),
        //        ForeColor = Color.Black,
        //        BackColor = Color.FromKnownColor(KnownColor.ControlLightLight)
        //    };
        //    styleNormal.SetBorderStyle(XLLineStyleEnum.Thin);
        //    styleNormal.SetBorderColor(Color.FromKnownColor(KnownColor.ControlDark));

        //    // Стиль колонок типа DateTime
        //    XLStyle styleDate = new XLStyle(book)
        //    {
        //        Format = "dd.MM.yyyy",
        //        Font = new Font("Tahoma", 9, FontStyle.Regular),
        //        ForeColor = Color.Black,
        //        BackColor = Color.FromKnownColor(KnownColor.ControlLightLight)
        //    };
        //    styleDate.SetBorderStyle(XLLineStyleEnum.Thin);
        //    styleDate.SetBorderColor(Color.FromKnownColor(KnownColor.ControlDark));

        //    string action = (sender as C1Command)?.Name; // определяем, какое событие обрабатывает метод

        //    int count = 0; // счетчик невидимых (отфильтрованных) строк

        //    for (int i = 0; i < Rows.Count; i++)
        //    {
        //        if (Rows[i].Visible)
        //        {
        //            // если нужно экспортировать только выделенные строки, пропускаем остальные
        //            if (action == "ExportSelected" && i >= Rows.Fixed && i < Rows.Count - Footers.Descriptions.Count && 
        //                SelectedRows.Count > 0 && !SelectedRows.Contains(i))
        //            {
        //                count++;
        //                continue;
        //            }

        //            for (int j = 0; j < Cols.Count; j++)
        //            {
        //                if (Cols[j].DataType == typeof(DateTime))
        //                {
        //                    var column = sheet.Columns[j];
        //                    column.Style = styleDate;
        //                }

        //                var cellValue = GetData(i, j);

        //                if (i < Rows.Fixed)
        //                {
        //                    sheet[i - count, j].Value = cellValue;
        //                    sheet[i - count, j].Style = styleFixed;

        //                    CellRange gridRange = GetMergedRange(i, j);

        //                    if (!gridRange.IsSingleCell)
        //                    {
        //                        XLCellRange xlRange = new XLCellRange(gridRange.r1, gridRange.r2, gridRange.c1, gridRange.c2);
        //                        book.Sheets[0].MergedCells.Add(xlRange);
        //                    }
        //                }
        //                else
        //                {
        //                    sheet[i - count, j].Value = cellValue;
        //                    if (Cols[j].DataType != typeof(DateTime))
        //                        sheet[i - count, j].Style = styleNormal;

        //                    if (Footers.Fixed && i >= Rows.Count - Footers.Descriptions.Count)
        //                        sheet[i - count, j].Style = styleFixed;
        //                }

        //                // Конвертируем пикселы в нативные единицы Excel
        //                var colWidthInPixels = Convert.ToDouble(Cols[j].WidthDisplay);
        //                var colWidthInTwips = C1XLBook.PixelsToTwips(colWidthInPixels);
        //                sheet.Columns[j].Width = colWidthInTwips;
        //            }
        //        }
        //        else
        //            count++;
        //    }

        //    string fileName = DateTime.Now.ToString().Replace(".", "").Replace(":", "").Replace(" ", "");
        //    string path = $"C:\\Windows\\Temp\\{fileName}.xls";
        //    book.Save(path);
        //    System.Diagnostics.Process.Start(path);
        //}

        // Экспорт в Excel
        public void ExportToExcel_Click(object sender, ClickEventArgs e)
        {
            bool? isXLExport = XLExportPredicate?.Invoke(this);

            if (isXLExport.HasValue)
            {
                if (!isXLExport.Value)
                    return;
            }

            C1XLBook book = new C1XLBook();

            XLSheet sheet = book.Sheets[0];
            sheet.Name = "List01";

            // Стиль фиксированных строк заголовка таблицы
            XLStyle styleFixed = new XLStyle(book)
            {
                Font = new XLFont("Tahoma", 9, false, false),
                //Font = new Font("Tahoma", 9, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.AliceBlue,
                //AlignHorz = XLAlignHorzEnum.Center,
                //AlignVert = XLAlignVertEnum.Center,
                WordWrap = true
            };
            styleFixed.SetBorderStyle(XLLineStyle.Thin);
            styleFixed.SetBorderColor(Color.FromKnownColor(KnownColor.ControlDark));

            // Стиль обычных строк
            XLStyle styleNormal = new XLStyle(book)
            {
                Font = new XLFont("Tahoma", 9, false, false),
                //Font = new Font("Tahoma", 9, FontStyle.Regular),
                ForeColor = Color.Black,
                BackColor = Color.FromKnownColor(KnownColor.ControlLightLight)
            };
            styleNormal.SetBorderStyle(XLLineStyle.Thin);
            styleNormal.SetBorderColor(Color.FromKnownColor(KnownColor.ControlDark));

            // Стиль колонок типа DateTime
            XLStyle styleDate = new XLStyle(book)
            {
                Format = "dd.MM.yyyy",
                Font = new XLFont("Tahoma", 9, false, false),
                //Font = new Font("Tahoma", 9, FontStyle.Regular),
                ForeColor = Color.Black,
                BackColor = Color.FromKnownColor(KnownColor.ControlLightLight)
            };
            styleDate.SetBorderStyle(XLLineStyle.Thin);
            styleDate.SetBorderColor(Color.FromKnownColor(KnownColor.ControlDark));

            // Стиль для числовых значений с 2 знаками после запятой
            XLStyle styleNumber = new XLStyle(book)
            {
                Format = "0.00", // Формат с двумя знаками после запятой
                Font = new XLFont("Tahoma", 9, false, false),
                //Font = new Font("Tahoma", 9, FontStyle.Regular),
                ForeColor = Color.Black,
                BackColor = Color.FromKnownColor(KnownColor.ControlLightLight)
            };
            styleNumber.SetBorderStyle(XLLineStyle.Thin);
            styleNumber.SetBorderColor(Color.FromKnownColor(KnownColor.ControlDark));

            string action = (sender as C1Command)?.Name; // определяем, какое событие обрабатывает метод

            int count = 0; // счетчик невидимых (отфильтрованных) строк

            for (int i = 0; i < Rows.Count; i++)
            {
                if (Rows[i].Visible)
                {
                    // если нужно экспортировать только выделенные строки, пропускаем остальные
                    if (action == "ExportSelected" && i >= Rows.Fixed && i < Rows.Count - Footers.Descriptions.Count &&
                        SelectedRows.Count > 0 && !SelectedRows.Contains(i))
                    {
                        count++;
                        continue;
                    }

                    for (int j = 0; j < Cols.Count; j++)
                    {
                        // Устанавливаем стиль для колонок с датами
                        // Но не применяем его к колонке целиком, а будем применять к каждой ячейке отдельно

                        var cellValue = GetData(i, j);

                        if (i < Rows.Fixed)
                        {
                            sheet[i - count, j].Value = cellValue;
                            sheet[i - count, j].Style = styleFixed;

                            CellRange gridRange = GetMergedRange(i, j);

                            if (!gridRange.IsSingleCell)
                            {
                                XLCellRange xlRange = new XLCellRange(gridRange.r1, gridRange.r2, gridRange.c1, gridRange.c2);
                                book.Sheets[0].MergedCells.Add(xlRange);
                            }
                        }
                        else
                        {
                            sheet[i - count, j].Value = cellValue;

                            if (Cols[j].DataType == typeof(DateTime))
                            {
                                // Применяем стиль даты к каждой ячейке
                                sheet[i - count, j].Style = styleDate;
                            }
                            else if (Cols[j].DataType == typeof(double) || Cols[j].DataType == typeof(decimal) ||
                                     Cols[j].DataType == typeof(float) || Cols[j].DataType == typeof(int))
                            {
                                // Применяем стиль с форматированием для чисел
                                sheet[i - count, j].Style = styleNumber;
                            }
                            else
                            {
                                sheet[i - count, j].Style = styleNormal;
                            }

                            if (Footers.Fixed && i >= Rows.Count - Footers.Descriptions.Count)
                                sheet[i - count, j].Style = styleFixed;
                        }

                        // Конвертируем пикселы в нативные единицы Excel
                        var colWidthInPixels = Convert.ToDouble(Cols[j].WidthDisplay);
                        var colWidthInTwips = C1XLBook.PixelsToTwips(colWidthInPixels);
                        sheet.Columns[j].Width = colWidthInTwips;
                    }
                }
                else
                    count++;
            }

            string fileName = DateTime.Now.ToString().Replace(".", "").Replace(":", "").Replace(" ", "");
            string path = $"C:\\Windows\\Temp\\{fileName}.xls";
            book.Save(path);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true });
            //System.Diagnostics.Process.Start(path);
        }

        private void HideSelectedColumn_Click(object sender, EventArgs e)
        {
            var hit = this.HitTest(((ClickEventArgs)e).ContextInfo.Location.X, ((ClickEventArgs)e).ContextInfo.Location.Y);

            int colIndex = this.Col;
            _hiddenColumns.Add(colIndex);

            if (colIndex >= 0 && colIndex < this.Cols.Count)
            {
                // Перемещаем выделение, чтобы не скрывать активную ячейку
                this.Col = (colIndex > 0) ? colIndex - 1 : colIndex + 1;

                this.Cols[colIndex].Visible = false;
            }

            _cmdShowHiddenColumns.Visible = true;
        }

        private void ShowHiddenColumns_Click(object sender, EventArgs e)
        {
            foreach (var col in _hiddenColumns)
            {
                this.Cols[col].Visible = true;
            }
            _cmdShowHiddenColumns.Visible = false;
        }

        public void SmartGrid_AddHeader()
        {

        }

        #endregion

        // Тултипы для ячеек грида
        // Для полноценной работы в конструкторе формы необходимо привязать свойство ToolTip грида к компоненту С1SuperToolTip, положенному на форму 
        // А.Кузнецов 19.10.2023
        #region Тултип

        public C1SuperTooltip ToolTip { get; set; } = new C1SuperTooltip();

        private void SmartGrid_MouseEnterCell(object sender, RowColEventArgs e)
        {
            string tip;

            if (e.Row >= Rows.Fixed && e.Row < Rows.Count - this.Footers.Descriptions.Count)
            {
                tip = String.Format("{0:" + this.Cols[e.Col].Format + "}", this[e.Row, e.Col]);
                ToolTip.SetToolTip(this, tip);
            }
        }

        private void SmartGrid_MouseLeaveCell(object sender, RowColEventArgs e)
        {
            ToolTip.SetToolTip(this, null);
        }

        #endregion


        // Изменение размеров шрифта в ячейках грида с помощью колеса мыши
        // А.Кузнецов 24.05.2024
        #region Ресайз шрифта колесом мыши / Свойства и методы

        private float currentFontSize = 10f; // Устанавливаем исходный размер шрифта
        private const float MinFontSize = 8f; // Минимальный размер шрифта
        private const float MaxFontSize = 20f; // Макс. размер шрифта

        private void FlexGrid_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.Delta > 0)
                {
                    // Если колесо крутится вверх, шрифт увеличивается
                    currentFontSize += 1f;

                    if (currentFontSize > MaxFontSize) // Устанавливаем верхнее ограничение
                        currentFontSize = MaxFontSize;
                }
                else if (e.Delta < 0)
                {
                    // Если колесо критится вниз, шрифт уменьшается
                    currentFontSize -= 1f;

                    if (currentFontSize < MinFontSize) // Устанавливаем нижнее ограничение
                        currentFontSize = MinFontSize;
                }

                // Применяем новый шрифт
                this.Font = new Font(this.Font.FontFamily, currentFontSize);
                this.Invalidate(); // Перерисовываем грид с новым размером шрифта
            }
        }

        #endregion

        // Установка изначальной сортировки грида
        // По умолчанию FlexGrid предоставляет возможность сортировать загруженные данные только по возрастанию (ascending)
        // и по убыванию (descending). Нижеследующий код добавляет возможность восстановить
        // изначальную сортировку данных (в том виде как они были получены из БД). В данном случае после сортировки по убыванию
        // значение SortFlags, определяющее порядок сортировки, снова устанавливается в положение None, что позволяет осуществить рефреш данных.
        // Для активации этой функции достаточно в конструкторе формы записать в делегат грида SetDefaultSorting
        // свой метод загрузки данных в грид.
        // А.Кузнецов, июнь 2024
        #region Установка сортировки грида по умолчанию. Свойства и методы

        /// <summary>
        /// Делегат для метода загрузки данных в грид для воостановления изначальной сортировки 
        /// <para>
        /// В конструкторе формы добавьте в этот делегат свой метод рефреша данных грида, например:
        /// </para>
        /// <code>
        /// MasterGrid.SetDefaultSorting += RefreshMaster;
        /// </code>
        /// <para>
        /// Порядок при сортировке (кликах по заголовкам столбцов с разрешенной сортировкой) будет следующим: по возрастанию, по убыванию, по умолчанию. 
        /// </para>
        /// </summary>
        public event Action SetDefaultSorting;

        private void SmartGrid_BeforeSort(object sender, SortColEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(this.SortDefinition);
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("ColumnSort");

            if (nodeList.Count > 0 && nodeList[0].Attributes["Sort"].Value.Contains("Descending"))
            {
                e.Order = SortFlags.None;
            }
        }

        private void SmartGrid_AfterSort(object sender, SortColEventArgs e)
        {
            if (e.Order == SortFlags.None)
            {
                SetDefaultSorting?.Invoke();
            }
        }


        #endregion


        // Форматирование футера в соответствии с форматом колонки.
        // А. Кузнецов, август 2024
        // Значения в ячейках футера в C1FlexGrid записываются в виде строки, составленной из соответствующего caption и результата агрегации данных.
        // Поэтому по умолчанию значение агрегации не форматируется в соответствии с установленным форматом столбца.
        // Чтобы корректно отобразить числовые данные (разрядку, цифры после запятой), нужно извлечь число из строки, применить формат и вернуть caption.      
        #region Форматирование футера. Свойства и методы

        /// <summary>
        /// Обрабатывает событие отрисовки ячейки (OwnerDrawCell), форматируя текст в ячейках футера на основе агрегированных данных.
        /// Определяет правильный description для текущей строки футера и добавляет к значению ячейки соответствующий caption, предотвращая дублирование.
        /// Форматирует значение ячейки в зависимости от типа данных столбца (double, decimal, int).
        /// Обрабатывает различные агрегаты, такие как Sum, Average, Percent, Min, и Max.
        /// </summary>
        private void SmartGrid_OwnerDrawCell(object sender, C1.Win.FlexGrid.OwnerDrawCellEventArgs e)
        {
            FooterCollection collection = this.Footers.Descriptions;
            int footerStartRow = this.Rows.Count - this.Footers.Descriptions.Count;

            // Проверяем, что мы находимся в строке футера
            if (e.Row >= footerStartRow)
            {
                // Определяем соответствующий description для текущей строки футера
                int descriptionIndex = e.Row - footerStartRow;
                if (descriptionIndex < collection.Count)
                {
                    var description = collection[descriptionIndex];

                    for (int i = 0; i < description.Aggregates.Count; i++)
                    {
                        if (e.Col == description.Aggregates[i].Column &&
                            (description.Aggregates[i].Aggregate == AggregateEnum.Sum ||
                             description.Aggregates[i].Aggregate == AggregateEnum.Average ||
                             description.Aggregates[i].Aggregate == AggregateEnum.Percent ||
                             description.Aggregates[i].Aggregate == AggregateEnum.Min ||
                             description.Aggregates[i].Aggregate == AggregateEnum.Max))
                        {
                            Type type = this.Cols[e.Col].DataType;
                            string format = this.Cols[e.Col].Format;
                            object value = null;

                            if (!string.IsNullOrEmpty(description.Aggregates[i].Caption))
                                e.Text = e.Text.Replace(description.Aggregates[i].Caption, "");

                            if (type != null && !string.IsNullOrWhiteSpace(e.Text))
                            {
                                try
                                {
                                    value = Convert.ChangeType(e.Text, type);

                                    if (type == typeof(double))
                                    {
                                        double val = (double)value;
                                        e.Text = val.ToString(format);
                                    }
                                    else if (type == typeof(decimal))
                                    {
                                        decimal val = (decimal)value;
                                        e.Text = val.ToString(format);
                                    }
                                    else if (type == typeof(int))
                                    {
                                        int val = (int)value;
                                        e.Text = val.ToString(format);
                                    }
                                    else
                                    {
                                        e.Text = value.ToString();
                                    }
                                }
                                catch (InvalidCastException ex)
                                {
                                    Console.WriteLine($"Ошибка преобразования: {ex.Message}");
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine($"Ошибка форматирования: {ex.Message}");
                                }
                            }

                            // Добавляем caption только для этой строки
                            e.Text = string.Concat(description.Aggregates[i].Caption, e.Text);

                            // Прерываем цикл, чтобы не было дублирования
                            break;
                        }
                    }
                }
            }
        }

        #endregion


        // Копия функционала TreeFlexGrid из библиотеки Tools (авторы А.Вахтеев, Н.Ананьев) для тех случаев, когда кроме иерархии в гриде требуется формировать сложные многоуровневые заголовки. Проведен рефакторинг кода (добавлены комментарии, переименованы некоторые переменные, исключена часть методов).
        // TODO Требуется более глубокий рефакторинг.
        // А. Кузнецов, ноябрь 2024
        #region Построение иерархии (дерева)

        #region Свойства, события, переменные

        public event Action AfterComplited;

        public delegate void SetCurrentValuesDelegate(Row rw);

        /// <summary>
        /// Событие, вызываемое при изменении текущей выбранной строки грида).
        /// </summary> 
        public event SetCurrentValuesDelegate SetCurrentValues;

        /// <summary>
        /// Делегат действий с узлом
        /// </summary>
        /// <param name="node">Ссылка узел</param>
        public delegate void NodeAction(Node node);

        /// <summary>
        /// Делегат переноса узла дерева(смены его родителя)
        /// </summary>
        /// <param name="currentNode">Ссылка на переносимый узел</param>
        /// <param name="parentNode">Ссылка на потенциальнй родительский узел</param>
        /// <param name="allowMove">Ссылка на переменную, отвечающую за то будет ли узел добавлен (используется в BeforeNodeMove)</param>
        [Browsable(false)]
        public delegate void NodeMoveDelegate(Node currentNode, Node parentNode, ref bool allowMove);

        /// <summary>
        /// Событие, срабатывающее перед переносом узла дерева (смены его родителя), можно использовать для проверок корректности переноса
        /// </summary>
        public event NodeMoveDelegate BeforeNodeMove;

        /// <summary>
        /// Событие, срабатывающее после переноса узла дерева (смены его родителя), можно использовать для внесения изменений в базу данных
        /// </summary>
        public event NodeMoveDelegate AfterNodeMove;

        public Func<RowCollection> MultiRowSelect;

        /// <summary>
        /// Делегат для проверки возможности переноса узла с дополнительными данными
        /// </summary>
        public delegate bool ValidateDragTargetDelegate(Node source, Node target);

        public event ValidateDragTargetDelegate ValidateDragTarget;

        /// <summary>
        /// Назавние столбца, содержащего id в пререданной таблице.
        /// </summary>
        public string IdName { get; set; }

        private static SortingType TYPE = SortingType.Descending;

        /// <summary>
        /// Тип сортировки Нодов
        /// </summary>
        public SortingType SortingType
        {
            get { return TYPE; }
            set { TYPE = value; }
        }

        private IComparer comparer = new RowsComparer(TYPE);

        public IComparer Comparer
        {
            get { return comparer; }
            set { comparer = value; }
        }

        public bool AllowNodeMove { get; set; }

        private int _selectedID = 0;

        /// <summary>
        /// Возвращает текущую строку грида
        /// </summary>
        public Row CurrRow => Rows[Row];

        ///// <summary>
        ///// Id текущей выделенной записи, при изменении значения будет выделена новая строка
        ///// </summary>
        //[Browsable(false)]
        //public int SelectedID
        //{
        //    get
        //    {
        //        _selectedID = Convert.ToInt32(CurrRow[IdName]);
        //        return _selectedID;
        //    }
        //    set
        //    {
        //        SetSelectedRow(value);
        //    }
        //}

        /// <summary>
        /// Cписок id выделенных строк из бд
        /// </summary>
        [Browsable(false)]
        public List<int> SelectedIds => SetSelectedIds(SelectedRows);

        /// <summary>
        /// Cписок id из бд выбранного узла   
        /// </summary>
        [Browsable(false)]
        public List<int> SelectedNodeIds => SetSelectedNodeIds();

        /// <summary>
        /// Перетаскиваемый узел
        /// </summary>
        private Node _dragedNode;

        /// <summary>
        /// Выделенный узел
        /// </summary>
        private Node _selectedNode;

        /// <summary>
        /// Признак перетаскивания узла
        /// </summary>
        private bool _isDragging = false;

        /// <summary>
        /// Начальный узел при перетаскивании
        /// </summary>
        private Point _dragStartPoint;

        /// <summary>
        /// Тултип для перетаскиваемого узла
        /// </summary>
        private ToolTip _dragToolTip;



        #endregion

        #region Методы

        /// <summary>
        /// Построение иерархии по перечислению модели указанного типа
        /// </summary>
        /// <typeparam name="T">тип модели</typeparam>
        /// <param name="source">перечисление модели</param>
        public void BuildTree<T>(IEnumerable<T> source) where T : ITreeData, new()
        {

            T root = GenerateRoot<T>();

            if (this.Cols.Contains("Name"))
                Tree.Column = this.Cols["Name"].Index; // Задаем колонку для показа дерева
            else
                Tree.Column = 0;


            Rows.Count = Rows.Fixed; // Пропускаем строки заголовков
            if (Footers.Descriptions.Count > 0 && Rows.Count == Rows.Fixed) Rows.Count += Footers.Descriptions.Count;

            Rows.Add();
            //Rows[Rows.Count - 1].IsNode = true;
            Rows[Rows.Count - Footers.Descriptions.Count - 1].IsNode = true;
            //Rows[Rows.Count - Footers.Descriptions.Count - Rows.Fixed].IsNode = true;

            //SetModelToNode(Rows[Rows.Count - 1].Node, root);
            SetModelToNode(Rows[Rows.Count - Footers.Descriptions.Count - 1].Node, root);
            //SetModelToNode(Rows[Rows.Count - Footers.Descriptions.Count - Rows.Fixed].Node, root);

            source = source.OrderBy(m => m.ParentId).ToList();

            var rootChildren = source.Where(m => m.ParentId == 0);
            //AddChildsToNode(Rows[Rows.Count - 1].Node, rootChildren, source);
            AddChildsToNode(Rows[Rows.Count - Footers.Descriptions.Count - 1].Node, rootChildren, source);
            //AddChildsToNode(Rows[Rows.Count - Footers.Descriptions.Count - Rows.Fixed].Node, rootChildren, source);
        }

        /// <summary>
        /// Генерация корневого узла
        /// </summary>
        /// <typeparam name="T">тип модели</typeparam>
        /// <returns>модель основного корня</returns>
        private T GenerateRoot<T>() where T : ITreeData, new()
        {
            T result = new T();
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                if (prop.PropertyType == typeof(string) && prop.Name == "Name")
                {
                    prop.SetValue(result, "...");
                }
                else if (prop.PropertyType == typeof(int) && (prop.Name == "ParentId" || prop.Name == "Id"))
                {
                    prop.SetValue(result, 0);
                }
            }

            return result;
        }

        /// <summary>
        /// Построение дочерних узлов для указанного узла
        /// </summary>
        /// <typeparam name="T">тип модели</typeparam>
        /// <param name="parentNode">указанный узел</param>
        /// <param name="childs">перечисление дочерних узлов</param>
        /// <param name="source">перечисление всех моделей</param>
        private void AddChildsToNode<T>(Node parentNode, IEnumerable<T> childs, IEnumerable<T> source) where T : ITreeData, new()
        {
            Stack<(Node, IEnumerable<T>)> stack = new Stack<(Node, IEnumerable<T>)>();
            stack.Push((parentNode, childs));

            while (stack.Count > 0)
            {
                var (currentNode, currentChilds) = stack.Pop();

                foreach (var child in currentChilds)
                {
                    Node newChildNode = currentNode.AddNode(NodeTypeEnum.LastChild, "");
                    SetModelToNode(newChildNode, child);

                    var currChilds = source.Where(m => m.ParentId == child.Id);
                    if (currChilds.Any())
                    {
                        stack.Push((newChildNode, currChilds));
                    }
                }
            }
        }

        /// <summary>
        /// Установка модели в указанный узел
        /// </summary>
        /// <typeparam name="T">тип модели</typeparam>
        /// <param name="node">узел</param>
        /// <param name="model">модель</param>
        private void SetModelToNode<T>(Node node, T model) where T : ITreeData, new()
        {
            node.Key = model;
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                if (prop.CanRead && HasField(prop.Name))
                {
                    int rowIndex = node.Row.Index;

                    this[rowIndex, prop.Name] = prop.GetValue(model);
                }
            }
        }

        /// <summary>
        /// Проверка наличия поля с указанным названием в гриде
        /// </summary>
        /// <param name="fieldName">название поля</param>
        /// <returns></returns>
        private bool HasField(string fieldName)
        {
            if (Cols == null || Cols[fieldName] == null)
            {
                return false;
            }

            return Cols[fieldName].Index >= 0;
        }

        private void TreeFlexGrid_BeforeSort(object sender, SortColEventArgs e)
        {
            int colIndex = this.Col;
            if (this.Nodes.Count() > 0 && this.Nodes.First() != null)
            {
                if (SortingType == SortingType.Descending)
                {
                    Comparer = new RowsComparer(SortingType.Ascending, colIndex);
                    SortingType = SortingType.Ascending;
                    SortNodes();
                }
                else if (SortingType == SortingType.Ascending)
                {
                    Comparer = new RowsComparer(SortingType.Descending, colIndex);
                    SortingType = SortingType.Descending;
                    SortNodes();
                }
            }
        }

        private void TreeFlexGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (this.Rows.Count == 1
                    || this.Row > this.Rows.Count
                    || this.Row <= 1)
                    return;

                if (this.Rows[Row].Node.LastChild != null)
                    ExpandAndSetNextRow(this.Rows[Row].Node);
                else
                    ExpandAndSetNextRow(this.Rows[Row].Node);

                if (this.Row == this.Rows.Count)
                    SetSelection(this.Rows[Row].Node);

                if (this.Rows[Row].IsVisible == false)
                    this.CurrRow.Node.Parent.Collapsed = false;
                this.Focus();
            }
        }

        /// <summary>
        /// Выделение/Отмена выделения узла в гриде красным цветом
        /// </summary>
        /// <param name="node">узел</param>
        private void SetSelection(Node node)
        {
            if (SelectedRows.Contains(node.Row.Index))
            {
                SelectedRows.Remove(node.Row.Index);
                //node.Row.StyleNew.ForeColor = Color.Black;
            }
            else
            {
                SelectedRows.Add(node.Row.Index);
                //node.Row.StyleNew.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Разворачивает узел при выделении, если он был свернут
        /// </summary>
        /// <param name="node"></param>
        private void ExpandAndSetNextRow(Node node)
        {
            SetSelection(node);

            if (node == null || this.Rows[node.Index + 1] == null)
                return;

            if (node.Children >= 1)
                node.Collapsed = false;

            SetNextRow();
        }

        /// <summary>
        /// Переводит курсор на следующую строку
        /// </summary>
        /// <param name="step"></param>
        private void SetNextRow(int step = 1)
        {
            if (this.Row + step < this.Rows.Count)
                this.Row += step;
            else if (this.Row + step - 1 == this.Rows.Count)
                SetSelection(this.Rows[Row].Node);
        }

        /// <summary>
        ///Обработчик события нажатия клавиши мыши
        /// </summary>
        private void TreeFlexGrid_MouseDown(object sender, MouseEventArgs e)
        {
            HitTestInfo hti = this.HitTest(e.Location);
            if (hti.Type == HitTestTypeEnum.Cell)
            {
                int rowIndex = hti.Row;
                if (!Rows[rowIndex].IsNode)
                    return;
                _dragedNode = Rows[rowIndex].Node;
                _dragStartPoint = e.Location;
                _isDragging = false;
            }
            else
            {
                _dragedNode = null;
            }
        }

        /// <summary>
        /// Обработчик события перемещения мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeFlexGrid_MouseMove(object sender, MouseEventArgs e)
        {
            // Устанавливаем перетаскивание только если кнопка мыши нажата и переместилась на минимальное расстояние
            if (_dragedNode != null && e.Button == MouseButtons.Left)
            {
                int dragThreshold = 5; // пикселей
                if (!_isDragging && (Math.Abs(e.X - _dragStartPoint.X) > dragThreshold ||
                    Math.Abs(e.Y - _dragStartPoint.Y) > dragThreshold))
                {
                    _isDragging = true;
                }

                if (_isDragging)
                {
                    bool canMove = true;
                    Node potentialTarget = null;

                    // Проверка выхода за пределы грида
                    if (e.X < 0 || e.Y < 0 || e.X > this.Width || e.Y > this.Height)
                    {
                        canMove = false;
                    }
                    else
                    {
                        // Определяем узел, над которым находится курсор
                        HitTestInfo hti = this.HitTest(e.Location);
                        if (hti.Type == HitTestTypeEnum.Cell && hti.Row >= 0 && hti.Row < Rows.Count)
                        {
                            if (Rows[hti.Row].IsNode)
                            {
                                potentialTarget = Rows[hti.Row].Node;

                                // Базовые проверки
                                if (potentialTarget.Row.Index == _dragedNode.Row.Index || // самого в себя
                                    potentialTarget.Row.Index == _dragedNode.Parent.Row.Index || // в текущего родителя
                                    IsSubroot(_dragedNode, potentialTarget)) // в свое поддерево 
                                {
                                    canMove = false;
                                }

                                // Только если прошли базовые проверки, вызываем пользовательскую валидацию
                                if (canMove && ValidateDragTarget != null)
                                {
                                    canMove = (bool)ValidateDragTarget?.Invoke(_dragedNode, potentialTarget);
                                }
                            }
                            else
                            {
                                canMove = false;
                            }
                        }
                        else
                        {
                            canMove = false;
                        }
                    }

                    // Установка курсора на основе результата проверки
                    this.Cursor = canMove ? Cursors.Hand : Cursors.No;

                    // Обновление тултипа если нужно
                    if (potentialTarget != null)
                    {
                        UpdateDragToolTip(e.Location);
                    }
                }
            }
        }

        private void UpdateDragToolTip(Point location)
        {
            if (_dragedNode != null && _isDragging)
            {
                // Получаем текст перетаскиваемого узла
                string nodeText = _dragedNode.Row["Name"].ToString();

                // Показываем тултип рядом с курсором
                _dragToolTip.Show(nodeText, this, location.X + 15, location.Y + 10, 3000);
            }
        }

        private void HideDragToolTip()
        {
            _dragToolTip.Hide(this);
        }

        /// <summary>
        ///Обработчик события отжатия клавиши мыши
        /// </summary>
        private void TreeFlexGrid_MouseUp(object sender, MouseEventArgs e)
        {
            HitTestInfo hit = this.HitTest(e.Location);

            if (hit.Type == HitTestTypeEnum.Cell)
            {
                int rowIndex = hit.Row;

                if (!Rows[rowIndex].IsNode)
                    return;

                _selectedNode = Rows[rowIndex].Node;

                if (AllowNodeMove && _isDragging && _dragedNode != null && _dragedNode != _selectedNode)
                    MoveNode(_dragedNode, _selectedNode);
            }

            this.Cursor = Cursors.Default;

            HideDragToolTip();

            // Сбрасываем состояние перетаскивания
            _isDragging = false;
            _dragedNode = null;
        }

        /// <summary>
        ///Метод переноса узла дерева(смены его родителя)
        /// </summary>
        /// <param name="currentNode">Ссылка на переносимый узел</param>
        /// <param name="parentNode">Ссылка на потенциальнй родительский узел</param>
        public bool MoveNode(Node currentNode, Node parentNode)
        {
            if (currentNode == null
                || parentNode == null
                || parentNode.Row.Index == currentNode.Row.Index
                || parentNode.Row.Index == currentNode.Parent.Row.Index)
                return false;

            bool allowMove = true;

            BeforeNodeMove?.Invoke(currentNode, parentNode, ref allowMove);

            if (!allowMove)
                return false;

            if (IsSubroot(currentNode, parentNode))
                //throw new Exception("ParentNode is a child of currentNode");
                return false;

            currentNode.Move(NodeMoveEnum.ChildOf, parentNode);

            AfterNodeMove?.Invoke(currentNode, parentNode, ref allowMove);

            return true;
        }

        /// <summary>
        /// Метод проверки является ли узел Node частью поддерева с корнем rootNode
        /// </summary>
        /// <param name="rootNode">ссылка на корень поддерева</param>
        /// <param name="Node">какой-то узел</param>
        public bool IsSubroot(Node rootNode, Node Node)
        {
            bool[] checkedNodes = new bool[Rows.Count];

            NodeAction nodeAction = (Node node) => checkedNodes[node.Row.Index] = true;

            CheckChilds(rootNode, nodeAction);

            return checkedNodes[Node.Row.Index];
        }

        /// <summary>
        /// Метод обхода поддерева
        /// </summary>
        /// <param name="node">ссылка на корень поддерева</param>
        /// <param name="nodeAction">Делегат хранящий ссылку на метод, принимающий ссылку на узел (Node) в качестве аргумента, 
        /// и который будет вызываться при заходе в каждый узел, можно использовать для действий с узлами при обходе дерева</param>
        public void CheckChilds(Node node, NodeAction nodeAction)
        {
            Stack<Node> stack = new Stack<Node>();

            stack.Push(node);

            while (stack.Count > 0)
            {
                Node curNode = stack.Pop();

                nodeAction?.Invoke(curNode);

                if (curNode.Children > 0)
                {
                    foreach (Node subNode in curNode.Nodes)
                    {
                        stack.Push(subNode);
                    }
                }
            }
        }

        /// <summary>
        /// Разворачивает указанный узел
        /// </summary>
        /// <param name="node">узел</param>
        public void ExpandBranch(Node node)
        {
            while (node != null)
            {
                node.Collapsed = false;
                node = node.Parent;
            }
        }

        /// <summary>
        /// Устанавливает стандартный режим для просмотра дерева
        /// </summary>
        private void ShowTree()
        {
            this.Tree.Column = 0;
            this.Tree.Style = TreeStyleFlags.SimpleLeaf;
            this.AutoSizeCols();
        }

        /// <summary>
        ///Метод, сворачивающий все узлы дерева
        /// </summary>
        /// <param name="startLevel">Уровень (Node.Level) с которого начать сворачивать узлы </param>    
        public void CollapseByLevel(int startLevel = 0)
        {
            foreach (Row Row in Rows)
            {
                if (Row.Node != null)
                {
                    if ((Row.Node.Level == startLevel))
                    {
                        Row.Node.Collapsed = !Row.Node.Collapsed;
                    }
                    else
                    {
                        Row.Node.Collapsed = (Row.Node.Level >= startLevel);
                    }
                }
            }
        }

        /// <summary>
        /// Метод который разворачивает все узлы дерева до startLevel
        /// </summary>
        /// <param name="startLevel">уровень до которого</param>
        public void ExpandByLevel(int startLevel = 0)
        {
            foreach (Row Row in Rows)
            {
                if (Row.Node != null)
                {
                    if (startLevel == 0)
                    {
                        Row.Node.Collapsed = true;
                    }
                    else if ((Row.Node.Level == startLevel - 1))
                    {
                        Row.Node.Expanded = true;
                    }
                    else
                    {
                        Row.Node.Expanded = (Row.Node.Level < startLevel);
                    }
                }
            }
        }

        /// <summary>
        ///Метод, меняющий текущую(выделенную) строку грида на другую, по id из БД
        /// </summary>
        /// <param name="id">id из БД записи на которую нужно встать</param>
        public void SetSelectedRow(int id)
        {
            if (String.IsNullOrEmpty(IdName) || id == -1)
                return;

            int index = FindRow(id.ToString(), 0, Cols[IdName].Index, true, true, true);
            if (index == -1)
                return;
            this.Row = index;
            _selectedID = id;
            ExpandBranch(Rows[Row].Node);
            SetCurrentValues?.Invoke(Rows[Row]);
        }

        /// <summary>
        /// Метод формирующий список состоящий из id в бд выделенных строк
        /// </summary>
        /// <param name="ids">Список номеров строк из который нужно сформировать список ids из бд</param>
        private List<int> SetSelectedIds(List<int> ids)
        {
            ids.Reverse();
            List<int> result = new List<int>();

            if (!string.IsNullOrEmpty(IdName) && ids.Count > 0)
                foreach (int id in ids)
                {
                    Row row = Rows[id];
                    result.Add(Convert.ToInt32(Rows[id][IdName]));
                }

            return result;
        }

        /// <summary>
        /// Метод, формирующий список id из бд у выбранного узла
        /// </summary>
        private List<int> SetSelectedNodeIds()
        {
            List<int> selectedNodeIds = new List<int>();

            NodeAction action = (Node node) => selectedNodeIds.Add(Convert.ToInt32(Convert.ToInt32(Rows[node.Row.Index][IdName])));

            CheckChilds(CurrRow.Node, action);

            return selectedNodeIds;
        }

        /// <summary>
        /// Добавление нового узла как дочернего к текущему узлу
        /// </summary>
        /// <param name="row">Данные для добавления</param>
        public void AddNodeToCurrentNode(DataRow row)
        {
            AddNode(Rows[Row].Node, row);
        }

        /// <summary>
        /// Добавление нового узла как дочернего к любому указанному узлу
        /// </summary>
        /// <param name="ParentNode">узел, к которому добавляем</param>
        /// <param name="row">данные для добавления</param>
        public void AddNode(Node ParentNode, DataRow row)
        {
            ParentNode.AddNode(NodeTypeEnum.LastChild, "");

            foreach (DataColumn col in row.Table.Columns)
            {
                ParentNode.LastChild.Row[col.ColumnName] = row[col.ColumnName];
            }
        }

        /// <summary>
        /// Обновление данных текущего узла
        /// </summary>
        /// <param name="row">данные для обновления</param>
        public void UpdateCurrentNode(DataRow row)
        {
            UpdateNode(Rows[Row].Node, row);
        }

        /// <summary>
        /// Обновление данных любого указанного узла
        /// </summary>
        /// <param name="node">узел, который обновляем</param>
        /// <param name="row">данные для обновления</param>
        public void UpdateNode(Node node, DataRow row)
        {
            for (int j = 0; j < row.Table.Columns.Count; j++)
            {
                node.LastChild.Row[j] = row[j];
            }
        }

        /// <summary>
        ///Метод, добавляющий картинки узлам
        /// </summary>
        /// <param name="typeField">Названия поля (колонки), значения которого влияют на отображаемые картинки</param>
        /// <param name="dict">Словарь соотносящий значения typeField с соответствующей картинкой</param>
        public void SetImages(string typeField, Dictionary<string, Image> dict)
        {
            for (int i = Rows.Fixed; i < Rows.Count; i++)
            {
                foreach (var item in dict)
                {
                    if (Rows[i][typeField]?.ToString() == item.Key)
                        Rows[i].Node.Image = item.Value;
                }
            }
        }

        /// <summary>
        ///Метод, добавляющий картинки конкретным полям
        /// </summary>
        /// <param name="typeField">Названия поля (колонки), значения которого влияют на отображаемые картинки</param>
        /// <param name="dict">Словарь соотносящий значения typeField с соответствующей картинкой</param>
        public void SetImagesToConcreteColumn(string typeField, Dictionary<string, Image> dict)
        {
            for (int i = Rows.Fixed; i < Rows.Count; i++)
            {
                foreach (var item in dict)
                {
                    if (Rows[i][typeField]?.ToString() == item.Key)
                    {
                        Rows[i][typeField] = "";
                        SetCellImage(i, typeField, item.Value);
                    }
                }
            }
        }

        /// <summary>
        ///Метод, добавляющий картинки узлам
        /// </summary>
        /// /// <param name="img">Картинка</param>
        public void SetImages(Image img)
        {
            for (int i = Rows.Fixed; i < Rows.Count; i++)
            {
                Rows[i].Node.Image = img;
            }
        }

        /// <summary>
        /// Получает максимальный уровень глубины узлов
        /// </summary>
        /// <returns>максимальный уровень</returns>
        public int GetDepth()
        {
            int maxLevel = 0;
            foreach (Row row in Rows)
            {
                if (row.Node?.Level > maxLevel)
                {
                    maxLevel = row.Node.Level;
                }
            }
            return maxLevel;
        }

        /// <summary>
        ///Cортирует дерево
        /// </summary>
        public void SortNodes()
        {
            NodeAction nodeAction = StandartSort;
            CheckChilds(this.Nodes.First(), nodeAction);
        }

        /// <summary>
        /// Сортирует дерево по определенному условию в компарере
        /// </summary>
        /// <param name="rowComparer">компарер</param>
        public void SortNodes(RowsComparer rowComparer)
        {
            comparer = rowComparer;
            SortNodes();
        }

        /// <summary>
        /// Сортирует дерево по полю и направлению
        /// </summary>
        /// <param name="field">поле</param>
        /// <param name="sortingType">направление сортировки</param>
        public void SortNodes(string field, SortingType sortingType)
        {
            comparer = new RowsComparer(sortingType, field);
            SortNodes();
        }

        /// <summary>
        /// Сортирует узел
        /// </summary>
        /// <param name="node">узел</param>
        private void StandartSort(Node node)
        {
            if (node.Children == 0)
                return;

            node.Sort(Comparer);
        }

        /// <summary>
        /// Установка значения узлу
        /// <typeparam name="T">Тип объекта модели для изменения значения узла</typeparam>
        /// <param name="node">узел значение которого нужно изменить</param>
        /// <param name="value">объект для изменения значения узла</param>
        private void SetValueToNode<T>(Node node, T value) where T : class, ITreeData
        {
            foreach (var prop in typeof(T).GetProperties())
                node.Row[prop.Name] = prop.GetValue(value);

            node.Key = value;
            this.Row = node.Row.Index;
        }

        /// <summary>
        /// Возвращает объект текущей выделенной строки
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <returns>Возвращает объект текущей выделенной строки</returns>
        public T GetCurrentObj<T>() where T : class, ITreeData => (T)CurrRow.Node.Key;

        /// <summary>
        /// Возвращает объект родителя текущей выделенной строки
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <returns>Возвращает объект родителя текущей выделенной строки</returns>
        public T GetObjOfParentCurrentNode<T>() where T : class, ITreeData => (T)CurrRow.Node.Parent.Key;

        /// <summary>
        /// Метод, возвращающий список объектов выбранного узла включая дочерние узлы и его самого
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <returns></returns>
        public List<T> GetObjFromCurrentNode<T>() where T : class, ITreeData
        {
            List<T> models = new List<T>();

            NodeAction nodeAction = (Node node) =>
            {
                if (node != Nodes.First())
                    models.Add(GetObjFromNode<T>(node));
            };

            CheckChilds(CurrRow.Node, nodeAction);

            return models;
        }

        /// <summary>
        /// метод добавляющий новый узел с данными к текущему выбранному узлу
        /// </summary>
        /// <typeparam name="T">Тип объекта для вставки</typeparam>
        /// <param name="value">значение для вставки в грид у выделенного узла</param>
        public void AddNodeToCurrentNode<T>(T value) where T : class, ITreeData
        {
            if (CurrRow.Node == this.Nodes.First())
            {
                this.Nodes.First().AddNode(NodeTypeEnum.LastChild, "");
                SetValueToNode(this.Nodes.First().LastChild, value);
                this.Row = this.Nodes.First().LastChild.Row.Index;
            }
            else
            {
                CurrRow.Node.AddNode(NodeTypeEnum.LastChild, "");
                SetValueToNode(CurrRow.Node.LastChild, value);
                this.Row = CurrRow.Node.LastChild.Row.Index;
            }
        }

        /// <summary>
        /// Установка значения текущему узлу
        /// <typeparam name="T">Тип объекта модели для изменения значения узла</typeparam>
        /// <param name="value">объект для изменения значения узла</param>
        public void SetValueToCurrentNode<T>(T value) where T : class, ITreeData => SetValueToNode(CurrRow.Node, value);

        /// <summary>
        /// Метод, возвращающий список id выделенного узла
        /// </summary>
        /// <typeparam name="T">Тип модели из которой берётся id</typeparam>
        /// <returns>Список id выделенного узла</returns>
        public List<int> GetSelectedNodeIds<T>() where T : class, ITreeData
        {
            List<int> ids = new List<int>();
            NodeAction nodeAction = (Node node) => ids.Add(GetObjFromNode<T>(node).Id);
            CheckChilds(CurrRow.Node, nodeAction);
            return ids;
        }

        /// <summary>
        /// Возвращает экземпляр модели из указанного узла
        /// </summary>
        /// <typeparam name="T">тип модели</typeparam>
        /// <param name="node">узел</param>
        private T GetObjFromNode<T>(Node node) where T : class, ITreeData => (T)node.Key;

        #endregion
        #endregion
    }
}
