namespace Hajos
{
    public partial class Form1 : Form
    {
        List<Kerdes> OsszesKerdes;
        List<Kerdes> AktualisKerdes = new List<Kerdes>();
        int MegjelenintettKerdesSzama = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //OsszesKerdes = new List<Kerdes>(); //initialize, ekkor jon letre az objektum a memoriaban
            OsszesKerdes = KerdesekBeolvasasa();
            for (int i = 0; i < 7; i++)
            {
                AktualisKerdes.Add(OsszesKerdes[0]);
                OsszesKerdes.RemoveAt(0);
            }
            dataGridView1.DataSource = AktualisKerdes;

            KerdesMegjelenitese(AktualisKerdes[MegjelenintettKerdesSzama]);
        }

        void KerdesMegjelenitese(Kerdes kerdes)
        {
            label1.Text = kerdes.KerdesSzoveg;
            textBox1.Text = kerdes.Valasz1;
            textBox2.Text = kerdes.Valasz2;
            textBox3.Text = kerdes.Valasz3;

            if (string.IsNullOrEmpty(kerdes.URL))
            {
                pictureBox1.Visible = false;
            }
            else
            {
                pictureBox1.Visible = true;
                pictureBox1.Load("https://storage.altinum.hu/hajo/" + kerdes.URL);
            }
            textBox3.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox1.BackColor = Color.White;
        }


        List<Kerdes> KerdesekBeolvasasa()
        {
            List<Kerdes> kerdesek = new List<Kerdes>(); // = new();
            StreamReader sr = new StreamReader("hajozasi_szabalyzat_kerdessor_BOM.txt", true); //beolvasanal figyelembe veszi a 4byte kodot az elejen, alapbol ASCII
            //fajlt eleresi utvonala how?

            while (!sr.EndOfStream)
            {
                //bool? //igaz, hamis, null -> 3 erteke lehet
                //normalis int-nek nem lehet null az erteke csak ha int? van & null != nulla
                //string sor = sr.ReadLine() ?? ""; //string erteke ha null lenne
                string? sor = sr.ReadLine();
                string[] tomb = sor.Split("\t");

                if (tomb.Length != 7) continue;

                Kerdes k = new();
                k.KerdesSzoveg = tomb[1].ToUpper();
                k.Valasz1 = tomb[2].Trim('"'); //elejerol es fegerol levagja a spacet v a megadott karaktert
                k.Valasz2 = tomb[3].Trim('"');
                k.Valasz3 = tomb[4].Trim('"');
                k.URL = tomb[5];

                int x = 0;
                int.TryParse(tomb[6], out x); //k.HelyesValasz = int.Parse(tomb[6]);
                k.HelyesValasz = x;

                kerdesek.Add(k);

            }

            sr.Close(); //fajlt kotelezo bezarni
            return kerdesek;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MegjelenintettKerdesSzama++;
            if (MegjelenintettKerdesSzama == AktualisKerdes.Count) MegjelenintettKerdesSzama = 0;

            KerdesMegjelenitese(AktualisKerdes[MegjelenintettKerdesSzama]);
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.Salmon;
            if (AktualisKerdes[MegjelenintettKerdesSzama].HelyesValasz == 3)
            {
                textBox3.BackColor = Color.LightGreen;
                AktualisKerdes[MegjelenintettKerdesSzama].HelyesValaszokSzama++;
            }
            else
            {
                AktualisKerdes[MegjelenintettKerdesSzama].HelyesValaszokSzama = 0;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Salmon;
            if (AktualisKerdes[MegjelenintettKerdesSzama].HelyesValasz == 1)
            {
                textBox1.BackColor = Color.LightGreen;
                AktualisKerdes[MegjelenintettKerdesSzama].HelyesValaszokSzama++;
            }
            else
            {
                AktualisKerdes[MegjelenintettKerdesSzama].HelyesValaszokSzama = 0;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.Salmon;
            if (AktualisKerdes[MegjelenintettKerdesSzama].HelyesValasz == 2)
            {
                textBox2.BackColor = Color.LightGreen;
                AktualisKerdes[MegjelenintettKerdesSzama].HelyesValaszokSzama++;
            }
            else
            {
                AktualisKerdes[MegjelenintettKerdesSzama].HelyesValaszokSzama = 0;
            }
        }
    }
}