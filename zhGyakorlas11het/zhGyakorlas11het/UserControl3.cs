using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zhGyakorlas11het.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zhGyakorlas11het
{
    public partial class UserControl3 : UserControl
    {
        StudiesContext context = new StudiesContext();
        public UserControl3()
        {
            InitializeComponent();
            FillDataSource();
        }

        public void FillDataSource()
        {
            var instructors = from i in context.Instructors
                              select new
                              {
                                  Salutation = i.Salutation,
                                  Name = i.Name,
                                  Status = i.StatusFkNavigation.Name,
                                  Employement = i.EmployementFkNavigation.Name
                              };

            dataGridView1.DataSource = instructors.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SaveFileDialog sfd = new SaveFileDialog();
            //if (sfd.ShowDialog()) == DialogResult.OK)
            //{
            //    try
            //    {
            //        StreamWriter sw = new StreamWriter(sfd.FileName);
            //        var csv = new CsvWriter(sw, CultureInfo.InvariantCulture);
            //        csv.WriteRecords(instructors.ToList());

            //        sw.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }
    }
}
