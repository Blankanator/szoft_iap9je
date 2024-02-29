namespace VillogoGomb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int sor = 0; sor < 10; sor++)
            {
                for (int oszlop = 0; oszlop < 10; oszlop++)
                {
                    SzamoloGomb b = new SzamoloGomb();
                    //b.Width = 30;
                    //b.Height = 30;

                    //b.Left = ClientRectangle.Width / 2 - b.Width / 2; // vizszintesen kozepen
                    //b.Top = ClientRectangle.Height / 2 - b.Height / 2; // fuggolegesen kozepen
                    b.Left = oszlop * b.Width;
                    b.Top = sor * b.Height;
                    //b.Text = (sor*oszlop).ToString();
                    Controls.Add(b);

                }
            }
        }
    }
}