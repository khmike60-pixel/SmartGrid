using C1.DataCollection;
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
    public partial class MikeForm : Form
    {
        public MikeForm()
        {
            InitializeComponent();
        }

        private void MikeForm_Load(object sender, EventArgs e)
        {
            List<MikeModel> data = new List<MikeModel>();
            C1DataCollection<MikeModel> dataCollection = new C1DataCollection<MikeModel>(data);
            data = new MikeModel().Load();

            //smartGrid1.DataSource = dataCollection;
            smartGrid1.DataSource = data;
        }

        private void smartGrid1_RowColChange(object sender, EventArgs e)
        {
            var a = 0;
        }
    }
}
