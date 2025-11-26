using C1.Win.FlexGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartGrid
{
    public partial class HeadersEditForm : Form
    {
        private SmartGrid _grid;
        private bool _mergeFlag = false;
        public string[] Headers
        {
            get { return headersGrid.Headers; }
            set { headersGrid.Headers = value; }
        }

        public HeadersEditForm(SmartGrid currentGrid)
        {
            InitializeComponent();
            _grid = currentGrid;
            headersGrid.Rows.Count = currentGrid.Rows.Fixed;
            headersGrid.Cols.Count = currentGrid.Cols.Count;
            headersGrid.Cols[0].Width = currentGrid.Cols[0].Width;
            GetPreviousHeaders();
        }

        private void GetPreviousHeaders()
        {
            //Получаем ранее введенные заголовки таблицы.
            if (_grid.Headers != null)
            {
                headersGrid.AllowMerging = AllowMergingEnum.Free;

                string[][] cellHeaders = new string[_grid.Rows.Fixed][];

                for (int i = 0; i < _grid.Rows.Fixed; i++)
                {
                    //Проверяем на несовпадение текущего количества строк таблицы и предыдущего состояния, сохраненного в редакторе 
                    if (i < _grid.Headers.Length)
                    {
                        if (_grid.Headers[i] != null)
                        {
                            string[] cells = _grid.Headers[i].Split('\t');
                            cellHeaders[i] = cells;

                            for (int j = 0; j < cellHeaders[i].Length; j++)
                            {
                                //Проверяем на несовпадение текущего количества столбцов таблицы и предыдущего состояния, сохраненного в редакторе 
                                if (j < _grid.Cols.Count)
                                {
                                    headersGrid[i, j] = cellHeaders[i][j];
                                    headersGrid.Styles["Normal"].TextAlign = TextAlignEnum.CenterCenter;
                                }
                                else
                                    continue;

                                //Если ширина столбца изменена в Дизайнере
                                headersGrid.Cols[j].Width = _grid.Cols[j].Width;
                            }
                        }
                    }
                }
            }
        }

        //Получаем новые заголовки для таблицы в редакторе заголовков.
        private string[] GetHeaders()
        {
            string[] headers = new string[_grid.Rows.Fixed];
            int emptyStringCount = 0;
            int emptyCellCount = 0;

            for (int i = 0; i < headersGrid.Rows.Count; i++)
            {
                string cellString = "";

                for (int j = 0; j < headersGrid.Cols.Count; j++)
                {
                    //Заполняем и подсчитываем пустые ячейки до появления значения
                    if (headersGrid[i, j] == null || (string)headersGrid[i, j] == "")
                    {
                        if (j == headersGrid.Cols.Count - 1)
                        {
                            cellString += "...";
                            emptyCellCount++;
                            continue;
                        }

                        cellString += "..." + "\t";
                        emptyCellCount++;
                        continue;
                    }

                    if (j == headersGrid.Cols.Count - 1)
                    {
                        cellString += headersGrid[i, j];
                        continue;
                    }

                    cellString += headersGrid[i, j] + "\t";
                }

                //Если значений нет, фиксируем, что строка пустая
                if (emptyCellCount == headersGrid.Cols.Count)
                {
                    emptyStringCount++;
                    emptyCellCount = 0;
                    continue;
                }
                else
                    headers[i] = cellString;
            }

            //Если пользователь не ввел никаких данных ни в одну строку, очищаем Headers
            if (emptyStringCount == headersGrid.Rows.Count)
                headers = null;

            return headers;
        }


        private void ButtonOk_Click(object sender, EventArgs e)
        {
            headersGrid.Headers = GetHeaders();

            DialogResult = DialogResult.OK;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ButtonMerge_Click(object sender, EventArgs e)
        {
            headersGrid.AllowMerging = AllowMergingEnum.Free;

            if (!_mergeFlag)
            {
                for (int i = 0; i < headersGrid.Rows.Count; i++)
                {
                    headersGrid.Rows[i].AllowMerging = true;

                    for (int j = 0; j < headersGrid.Cols.Count; j++)
                    {
                        headersGrid.Cols[j].AllowMerging = true;
                    }
                }

                _mergeFlag = true;
                ButtonMerge.Text = "Unmerge";
            }
            else
            {
                for (int i = 0; i < headersGrid.Rows.Count; i++)
                {
                    headersGrid.Rows[i].AllowMerging = false;

                    for (int j = 0; j < headersGrid.Cols.Count; j++)
                    {
                        headersGrid.Cols[j].AllowMerging = false;
                    }
                }

                _mergeFlag = false;
                ButtonMerge.Text = "Merge preview";
            }
        }

    }
}
