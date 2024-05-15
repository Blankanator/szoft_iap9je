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
    public partial class UserControl2 : UserControl
    {
        StudiesContext context = new StudiesContext();
        public UserControl2()
        {
            InitializeComponent();
            FillDataSource();
        }
        public void FillDataSource()
        {
            listBox1.DataSource = (from i in context.Courses
                                   where i.Name.Contains(textBox1.Text)
                                   select i).ToList();
            listBox1.DisplayMember = "Name";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FillDataSource();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            Course selectedCourse = listBox1.SelectedItem as Course;

            var lessons = from l in context.Lessons
                          where l.CourseFk == selectedCourse.CourseSk
                          select new
                          {
                              Nap = l.DayFkNavigation.Name,
                              Sáv = l.TimeFkNavigation.Name,
                              Oktató = l.InstructorFkNavigation.Name
                          };

            dataGridView1.DataSource = lessons.ToList();
        }
    }
}
