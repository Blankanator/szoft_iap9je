using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace labirintus
{
    public partial class Form1 : Form
    {
        PictureBox jatekos = new();
        List<PictureBox> bricks = new();
        List<PictureBox> end = new();
        int steps = 0;
        int elapsedTime = 0;
        int level = 6;
        string fajl = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        public void playGame()
        {
            jatekos = new();
            //jatekos.Size = new(20, 20);
            jatekos.Top = 80;
            jatekos.Left = 0;
            jatekos.Height = 20;
            jatekos.Width = 20;
            jatekos.BackColor = Color.Fuchsia;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

            Controls.Add(jatekos);
            timer1.Start();
        }

        public void palya(string fajl) 
        {
            StreamReader sr = new StreamReader(fajl);

            int s = 0;
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                for (int o = 0; o < sor.Length; o++)
                {
                    if (sor[o] == '#')
                    {
                        PictureBox pb = new();
                        pb.Top = 60 + s * 20;
                        pb.Left = o * 20;
                        pb.Width = 20;
                        pb.Height = 20;
                        pb.BackColor = Color.Black;
                        Controls.Add(pb);
                        bricks.Add(pb);
                    }
                    else if (sor[o] == '-')
                    {
                        PictureBox pbend = new();
                        pbend.Top = 60 + s * 20;
                        pbend.Left = o * 20;
                        pbend.Width = 20;
                        pbend.Height = 20;
                        //pbend.BackColor = Color.Blue;
                        Controls.Add(pbend);
                        end.Add(pbend);
                    }

                }
                s++;
            }
            sr.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            palya($"p{level}.txt");
            playGame();
            this.KeyDown += Form1_KeyDown;

        }
        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {

            int x = jatekos.Location.X;
            int y = jatekos.Location.Y;


            if (e.KeyCode == Keys.Left)
            {
                x -= 20;
                steps++;
            }

            if (e.KeyCode == Keys.Right)
            {
                x += 20;
                steps++;
            }

            if (e.KeyCode == Keys.Up)
            {
                y -= 20;
                steps++;
            }

            if (e.KeyCode == Keys.Down)
            {
                y += 20;
                steps++;
            }

            //var brick = (from s in bricks
            //             where s.Left == x && s.Right == y
            //             select x).FirstOrDefault();

            var brick = bricks.Where(b => b.Left == x && b.Top == y).FirstOrDefault();

            if (brick == null)
            {
                jatekos.Left = x;
                jatekos.Top = y;
            }

            var endPoint = end.Where(e => e.Bounds.IntersectsWith(jatekos.Bounds)).FirstOrDefault();
            if (endPoint != null)
            {
                MessageBox.Show("You have exited the maze!");
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }

            label4.Text = steps.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedTime++;
            int minutes = elapsedTime / 60;
            int seconds = elapsedTime % 60;
            label2.Text = $"{minutes:D2}:{seconds:D2}";
            //label2.Text = timer1.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(ofd.FileName);

                    int s = 0;
                    while (!sr.EndOfStream)
                    {
                        string sor = sr.ReadLine();
                        for (int o = 0; o < sor.Length; o++)
                        {
                            if (sor[o] == '#')
                            {
                                PictureBox pb = new();
                                pb.Top = 60 + s * 20;
                                pb.Left = o * 20;
                                pb.Width = 20;
                                pb.Height = 20;
                                pb.BackColor = Color.Black;
                                Controls.Add(pb);
                                bricks.Add(pb);
                            }
                            else if (sor[o] == '-')
                            {
                                PictureBox pbend = new();
                                pbend.Top = 60 + s * 20;
                                pbend.Left = o * 20;
                                pbend.Width = 20;
                                pbend.Height = 20;
                                //pbend.BackColor = Color.Blue;
                                Controls.Add(pbend);
                                end.Add(pbend);
                            }
                        }
                        s++;
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            playGame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            steps = 0;
            elapsedTime = 0;

            playGame();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Remove all existing PictureBox controls from the form
            foreach (Control control in Controls.OfType<PictureBox>().ToList())
            {
                Controls.Remove(control);
                control.Dispose(); // Dispose the PictureBox to release resources
            }
            bricks.Clear();
            end.Clear();

            level++;
            if (level >= 7)
            {
                level = 1;
            }
            palya($"p{level}.txt");
            playGame();
        }
    }
}