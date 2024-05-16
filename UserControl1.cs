using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zh3_gyak
{
    public partial class UserControl1 : UserControl
    {
        Models.StudiesContext context = new Models.StudiesContext();
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            BackColor = Color.AliceBlue;

            var ilist = from i in context.Instructors
                        select i;

            var ilist2=context.Instructors.Select(i => i);

            listBox1.DataSource = ilist.ToList();
            listBox1.DisplayMember = "Name";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = context.Instructors.Where(x => x.Name.Contains(textBox1.Text)).ToList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            Models.Instructor selectedInstructor = listBox1.SelectedItem as Models.Instructor;

            var lessons = context.Lessons.Where(l => l.InstructorFk == selectedInstructor.InstructorSk).
                Select(y => new
                {
                    Kurzus = y.CourseFkNavigation.Name,
                    Nap = y.DayFkNavigation.Name,
                    Sáv = y.TimeFkNavigation.Name
                }
                ).ToList();

            dataGridView1.DataSource = lessons;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {

        }
    }
}
