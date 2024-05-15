namespace zhGyakorlas11het
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl1 userControl = new UserControl1();
            panel1.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl2 userControl = new UserControl2();
            panel1.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl3 userControl = new UserControl3();
            panel1.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl4 userControl = new UserControl4();
            panel1.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
        }
    }
}