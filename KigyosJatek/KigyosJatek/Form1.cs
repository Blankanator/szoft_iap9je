namespace KigyosJatek
{
    public partial class Form1 : Form
    {
        int lepesszam;

        int fej_x = 100;
        int fej_y = 100;

        int irany_x = 1;
        int irany_y = 0;

        Random rnd = new Random();

        int hossz = 5;
        List<KigyoElem> kigyo = new List<KigyoElem>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //List<string> list = new List<string>();

            //for (int i = 0; i < list.Count; i++)
            //{
            //    list[i] = xddd nem értem mit csinálunk
            //        játszik a professzor úr
            //    foreach (string item in list)
            //    {
            //        nice sos

            //    }
            //}


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lepesszam++;
            

            fej_x += irany_x * KigyoElem.Meret;
            fej_y += irany_y * KigyoElem.Meret;

            KigyoElem ke = new KigyoElem();
            ke.Top = fej_y;
            ke.Left = fej_x;
            kigyo.Add(ke);

            foreach (object item in Controls)
            {
                if (item is KigyoElem)
                {
                    KigyoElem k = (KigyoElem)item;

                    if (k.Top == fej_y && k.Left == fej_x)
                    {
                        timer1.Enabled = false;
                        return;
                    }
                }

                if (item is Alma)
                {
                    Alma al = (Alma)item;

                    if (al.Top == fej_y && al.Left == fej_x)
                    {
                        hossz++;
                        Controls.Remove(al);
                    }
                }

            }

            //Farokvágás
            if (kigyo.Count > hossz)
            {
                KigyoElem levagando = kigyo[0];
                kigyo.RemoveAt(0);
                Controls.Remove(levagando);
            }

            if (lepesszam % 10 == 0)
            {
                //ke.BackColor = Color.Green;

                int[] alma_hely = { 20, 40, 60, 80, 100, 120, 140, 160 };

                List<int> alma_helyek = new List<int>();
                alma_helyek.AddRange(alma_hely);

                Alma a = new Alma();
                int a_x = alma_helyek[rnd.Next(alma_helyek.Count)];
                int a_y = alma_helyek[rnd.Next(alma_helyek.Count)];
                a.Top = a_x;
                a.Left = a_y;
                Controls.Add(a);
            }




            Controls.Add(ke);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                irany_y = -1;
                irany_x = 0;
            }
            if (e.KeyCode == Keys.Down)
            {
                irany_y = 1;
                irany_x = 0;
            }
            if (e.KeyCode == Keys.Left)
            {
                irany_y = 0;
                irany_x = -1;
            }
            if (e.KeyCode == Keys.Right)
            {
                irany_y = 0;
                irany_x = 1;
            }
        }
    }
}