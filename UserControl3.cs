using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zh3_gyak
{
    public partial class UserControl3 : UserControl
    {
        Models.StudiesContext context = new Models.StudiesContext();
        public UserControl3()
        {
            InitializeComponent();
        }


        private void UserControl3_Load(object sender, EventArgs e)
        {
            var oktatos = (from i in context.Instructors
                                        join s in context.Statuses on i.StatusFk equals s.StatusId
                                        join p in context.Employements on i.EmployementFk equals p.EmployementId
                                        select new
                                        {
                                            Oktató = i.Name,
                                            Cím = i.Salutation,
                                            Státusz = s.Name,
                                            Munka = p.Name,
                                        }
                                        ).ToList();
            dataGridView1.DataSource = oktatos;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var oktatos = (from i in context.Instructors
                           join s in context.Statuses on i.StatusFk equals s.StatusId
                           join p in context.Employements on i.EmployementFk equals p.EmployementId
                           select new
                           {
                               Oktató = i.Name,
                               Cím = i.Salutation,
                               Státusz = s.Name,
                               Munka = p.Name,
                           }
                                        ).ToList();

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                    var csv = new CsvWriter(sw, CultureInfo.InvariantCulture);
                    csv.WriteRecords(oktatos);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
