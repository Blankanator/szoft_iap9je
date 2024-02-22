namespace Fibonacci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Sor> sorok = new List<Sor>();

            for (int i = 0; i < 10; i++)
            {
                Sor ujSor = new Sor();
                ujSor.Sorszam = i;
                ujSor.Ertek = Fibonacci(i);

                sorok.Add(ujSor);

                Button button = new();
                button.Top = i * 40;
                button.Left = 500;
                button.Width = 50;
                button.Height = 40;
                button.Text = Fibonacci(i).ToString();
                Controls.Add(button);
            }
            dataGridView1.DataSource = sorok;
        }

        int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}