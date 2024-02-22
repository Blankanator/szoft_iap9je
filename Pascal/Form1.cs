namespace Pascal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int m = 40;
            for (int sor = 0; sor < 10; sor++)
            {
                for (int oszlop = 0; oszlop < sor + 1; oszlop++)
                {
                    Button button = new Button();
                    Controls.Add(button);
                    button.Top = sor * m;
                    button.Left = oszlop * m - sor * m / 2 + Width / 2;
                    button.Width = m;
                    button.Height = m;

                    int x = Faktorialis(sor) / (Faktorialis(oszlop) * Faktorialis(sor - oszlop));
                    button.Text = x.ToString();
                }
            }
        }

        int Faktorialis(int n)
        {
            if (n == 0) return 1;
            return n * Faktorialis(n - 1);
        }

    }
}