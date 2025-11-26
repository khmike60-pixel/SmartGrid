using C1.DataCollection;
using C1.DataCollection.BindingList;
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
    public partial class DropDownForm2  : Form //: C1.Win.Input.DropDownForm
    {
        public DropDownForm2()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            var model = new MyModel();
            var data = new C1DataCollection<MyModel>(model.GetData());
            LoadData(data);
        }
        private void LoadData(C1DataCollection<MyModel> data)
        {
            Grid.BeginUpdate();
            Grid.DataSource = new C1DataCollectionBindingList(data);
            Grid.EndUpdate();
        }
    }
}
