using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp19
{
    public partial class FormÚjFutócs : Form
    {

        
        public Futó ÚjFutó = new Futó();
        public FormÚjFutócs()
        {
            InitializeComponent();
        }

        private void FormÚjFutócs_Load(object sender, EventArgs e)
        {
            futókBindingSource.DataSource = ÚjFutó;
        }
    }
}
