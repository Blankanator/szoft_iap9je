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
    public partial class UserControl2 : UserControl
    {
        Models.StudiesContext context = new Models.StudiesContext();
        public UserControl2()
        {
            InitializeComponent();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            BackColor = Color.PaleGoldenrod;

            var ilist = context.Courses.Select(x => x);
            listBox1.DataSource = ilist.ToList();
            listBox1.DisplayMember = "Name";

            var oktatószám = context.Courses.Count();
            label1.Text = oktatószám.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FillDataSource();
            //címkék

            int kurzusSzam = context.Courses.Where(x => x.Name.Contains(textBox1.Text)).Count();
            label1.Text = kurzusSzam.ToString();
            
        }
        void FillDataSource()
        {
            listBox1.DataSource = context.Courses.Where(x => x.Name.Contains(textBox1.Text)).ToList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            Models.Course selectedCourse = listBox1.SelectedItem as Models.Course;

            var lessons = context.Lessons.Where(x => x.CourseFk == selectedCourse.CourseSk).
                Select(y => new
                {
                    Nap = y.CourseFkNavigation.Name,
                    Sáv = y.TimeFkNavigation.Name,
                    Oktató = y.InstructorFkNavigation.Name
                }).ToList();

            int óraszám = lessons.Count();
            label2.Text = óraszám.ToString();

            dataGridView1.DataSource = lessons;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                Models.Course course = new Models.Course();
                course.Name = form2.textBox1.Text;
                context.Courses.Add(course);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex )
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
