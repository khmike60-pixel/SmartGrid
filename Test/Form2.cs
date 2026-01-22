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
        }

        private void RefreshTree()
        {
            Grid3.BeginUpdate();

            var model = new MyModel();
            var data = model.GetTreeData();
            LoadTreeData(data);

            Grid3.EndUpdate();

        }

        private void LoadTreeData(IEnumerable<MyModel> data)
        {
            Grid3.BuildTree(data);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            RefreshTree();

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

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //Grid3.BeginUpdate();

            RefreshTree();

            //Grid3.EndUpdate();
        }
    }
}
