using CsillagTerkep.Models;
using System.Drawing;

namespace CsillagTerkep
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();


        }

        private void buttonGraph_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen toll = new Pen(Color.White, 1); //color, width
            Brush ecset = new SolidBrush(Color.Yellow);

            //g.FillEllipse(ecset, 0, 0, 100, 100);

            hajosContext context = new hajosContext();
            var stars = (from s in context.StarData 
                         orderby s.Y
                         select new { s.Hip, s.X, s.Y, s.Magnitude }).ToList(); //anonim osztaly //var stars = from x in context.StarData select x;

            g.Clear(Color.Black); //rajztabla torlese

            double nagyitas = 300; // ne legyen minden 2 px helyen
            int cx = ClientRectangle.Width / 2; 
            int cy = ClientRectangle.Height / 2; //ablak kozepe

            foreach (var s in stars) {
                if (s.Magnitude > 6) continue;
                if (Math.Sqrt(Math.Pow(s.X, 2) + Math.Pow(s.Y, 2)) >1) continue;

                double x = s.X * nagyitas + cx;
                double y = s.Y * nagyitas + cy;

                double size = 20 * Math.Pow(10, s.Magnitude / -2.5);

                g.FillEllipse(ecset, (float)x, (float)y, (float)size, (float)size);
            
            }

            var lines = context.ConstellationLines.ToList();
            foreach (var line in lines)
            {
                var star1 = (from s in stars //context.StarData helyett, memoriabol dolgozik igy
                            where s.Hip == line.Star1 
                            select s).FirstOrDefault();
                var star2 = (from s in stars 
                             where s.Hip == line.Star2
                             select s).FirstOrDefault();

                if (star1 == null || star2 == null) continue;
                
                double x1 = star1.X * nagyitas + cx;
                double y1 = star1.Y * nagyitas + cy;

                double x2 = star2.X * nagyitas + cx;
                double y2 = star2.Y * nagyitas + cy;

                g.DrawLine(toll, (float)x1, (float)y1, (float)x2, (float)y2);
            }

            //var stars = (from s in context.StarData select new { s.Hip, s.X, s.Y, s.Magnitude }).ToList();
            //foreach (var s in stars)
            //{
            //    //Rajzolás
            //    Graphics g = this.CreateGraphics();

            //    g.Clear(Color.White);

            //    Color c = Color.Black;

            //    Pen toll = new Pen(c, 1);
            //    Brush brush = new SolidBrush(c);
            //}
        }
    }
}