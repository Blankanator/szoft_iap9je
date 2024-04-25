using _9het_adatbazisok.Models;
using Microsoft.Web.WebView2.Core;

namespace _9het_adatbazisok
{
    public partial class Form1 : Form
    {
        Models.StudentContext studentContext = new Models.StudentContext();
        public Form1()
        {
            InitializeComponent();
            studentBindingSource.DataSource = studentContext.Students.ToList();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                studentContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new();
            s.Name = "a";
            s.Neptun = "aaa111";

            studentContext.Students.Add(s);
        }
    }
}