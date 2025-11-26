using C1.DataCollection;
using C1.DataCollection.BindingList;
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

namespace Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            RefreshTree();
            Refresh();

            Grid.RemoveDefaultContextMenuItems(true, true, true);
            //Grid.AddItemToContextMenu("новый пункт", Resources.CopyDataFromTo_GI, null);
        }

        private void RefreshTree()
        {
            var model = new MyModel();
            var data = model.GetTreeData();
            LoadTreeData(data);
        }

        private void Refresh()
        {
            var model = new MyModel();
            var data = new C1DataCollection<MyModel>(model.GetData());
            LoadData(data);
        }

        private void LoadTreeData(IEnumerable<MyModel> data)
        {
            Grid.BuildTree(data);

            Grid.Rows[4].IsNode = false;
            Grid.Rows[5].IsNode = false;

            Grid3.BuildTree(data);

        }

        private void LoadData(C1DataCollection<MyModel> data)
        {
            Grid2.BeginUpdate();
            Grid2.DataSource = new C1DataCollectionBindingList(data);
            Grid2.EndUpdate();
        }

        private void Grid_BeforeFilter(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Grid_AfterFilter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private bool Grid3_ValidateDragTarget(Node source, Node target)
        {
            if (target.Row.UserData != null)
            {
                var userDataType = target.Row.UserData.GetType();
                var isLeafProperty = userDataType.GetProperty("IsLeaf");

                if (isLeafProperty != null)
                {
                    int isLeaf = (int)isLeafProperty.GetValue(target.Row.UserData);
                    if (isLeaf == 1)
                    {
                        return false; // Запрещаем перетаскивание на лист
                    }
                }
            }

            return true;
        }
    }
}
