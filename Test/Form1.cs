using C1.DataCollection;
using C1.DataCollection.BindingList;
using C1.Win.FlexGrid;
using C1.Win.Input;
//using GrapeCity.DataVisualization.Chart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Устанавливаем культуру перед инициализацией компонентов формы
            CultureInfo culture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            InitializeComponent();

            Refresh();
            //RefreshTree();

            //для установки сортировки по умолчанию записать в делегат ваш метод загрузки данных в грид
            Grid.SetDefaultSorting += Refresh;

            c1DropDownControl1.KeyPress += EditingControl_KeyPress;
            c1DropDownControl1.Leave += EditingControl_Leave;
            c1DropDownControl1.LostFocus += EditingControl_LostFocus;

        }

        private void Refresh()
        {
            var model = new MyModel();
            var data = new C1DataCollection<MyModel>(model.GetData());
            LoadData(data);
        }

        private void RefreshTree()
        {
            var model = new MyModel();
            var data = model.GetTreeData();
            LoadTreeData(data);
        }

        private void LoadData(C1DataCollection<MyModel> data)
        {
            Grid.BeginUpdate();
            Grid.DataSource = new C1DataCollectionBindingList(data);
            Grid.EndUpdate();
        }

        private void LoadTreeData(IEnumerable<MyModel> data)
        {
            Grid.BuildTree(data);
        }

        private void Grid_BeforeSort(object sender, C1.Win.FlexGrid.SortColEventArgs e)
        {

            //XmlDocument docXML = new XmlDocument();
            //docXML.LoadXml(Grid.SortDefinition);
            //XmlNodeList nodeList = docXML.GetElementsByTagName("ColumnSort");

            //if (nodeList.Count > 0 && nodeList[0].Attributes["Sort"].Value.Contains("Descending"))
            //{
            //    e.Order = SortFlags.None;
            //}
        }

        private void Grid_AfterSort(object sender, SortColEventArgs e)
        {
            //if (e.Order == SortFlags.None)
            //{
            //    SetDefaultSorting?.Invoke();
            //}
        }

        private void RestoreDefaultSorting()
        {

        }





        private void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Перехватываем нажатие Enter и закрываем выпадающий список только при нажатии Enter.
            if (e.KeyChar == (char)Keys.Enter)
            {
                //c1DropDownControl1.CloseDropDown();
            }
            else
            {
                //c1DropDownControl1.OpenDropDown();
            }
        }

        private void EditingControl_Leave(object sender, EventArgs e)
        {
            // Запрещаем закрытие выпадающего списка при потере фокуса текстовым полем.
            if (!c1DropDownControl1.DroppedDown)
            {
                //c1DropDownControl1.OpenDropDown();
            }
        }

        private void EditingControl_LostFocus(object sender, EventArgs e)
        {
            // Возвращаем фокус на текстовое поле, если оно теряется.
            c1DropDownControl1.Focus();
        }
    }
}
