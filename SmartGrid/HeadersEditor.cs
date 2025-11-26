using C1.Win.FlexGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartGrid
{
    [LicenseProvider(typeof(LicenseProvider))]
    public partial class HeadersEditor : C1FlexGrid
    {
        public string[] Headers { get; set; }
        public HeadersEditor()
        {
            Size = new Size(400, 150);
        }
    }
}
