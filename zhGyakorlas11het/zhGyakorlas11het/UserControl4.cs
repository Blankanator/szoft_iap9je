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

namespace zhGyakorlas11het
{
    public partial class UserControl4 : UserControl
    {
        StudiesContext context = new StudiesContext();
        public UserControl4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
            { 
                Room room = new Room();
                room.Name = form2.textBox1.Text;
                context.Rooms.Add(room);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            var courses = from c in context.Courses
                              select new
                              {
                                  Név = c.Name,
                                  //Nap = c.DayFkNavigation.Name,
                                  //Sáv = c.TimeFkNavigation.Name,
                                  //Oktató = c.InstructorFkNavigation.Name
                              };

            dataGridView1.DataSource = courses.ToList();
        }
    }
}
