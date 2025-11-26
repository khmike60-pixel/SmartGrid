using C1.Win;
using C1.Win.Input;



namespace SmartGrid
{
    public partial class SumForm : Form
    {
        private string _sum;
        public string Sum
        {
            get { return _sum; }
            set { _sum = value; OnChangeProperty(); }
        }

        public SumForm()
        {
            InitializeComponent();
        }

        private void OnChangeProperty()
        {
            SumTB.Value = _sum.ToString();
        }
        
    }
}
