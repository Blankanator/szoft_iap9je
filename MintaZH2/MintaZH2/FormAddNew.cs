using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MintaZH2
{
    public partial class FormAddNew : Form
    {
        public FutokData EditedFutokData = new();
        public FormAddNew()
        {
            InitializeComponent();
        }

        private void FormAddNew_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = EditedFutokData;
        }
    }
}
