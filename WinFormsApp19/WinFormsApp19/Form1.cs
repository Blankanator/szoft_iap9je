using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace WinFormsApp19
{
    public partial class Form1 : Form
    {
        BindingList<Fut�> fut�k = new();

        public Form1()
        {
            InitializeComponent();
            ////dataGridView1.DataSource = fut�k; ///!!!!!!!!!!!!!!
            ///
            fut�kBindingSource.DataSource = fut�k;
        }

        private void buttonBet�lt�s_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("futottakmeg.txt");
                var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
                var t = csv.GetRecords<Fut�>();

                foreach (var item in t)
                {
                    fut�k.Add(item);
                }

                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonMent�s_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                    var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                    csv.WriteRecords(fut�k);

                    streamWriter.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fut�kBindingSource.Current == null) return;

            if (MessageBox.Show("A", "B", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                fut�kBindingSource.RemoveCurrent();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form�jFut�cs form�jFut�cs = new Form�jFut�cs();
            form�jFut�cs.�jFut� = fut�kBindingSource.Current as Fut�;

            form�jFut�cs.Show();

            //if (form�jFut�cs.ShowDialog() == DialogResult.OK)
            //{
            //    fut�kBindingSource.Add(form�jFut�cs.�jFut�);
            //}

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double minimum = double.PositiveInfinity;
            string leggyorsabb = string.Empty;

            foreach (var item in fut�k)
            {
                if (item.EredmenyPerc <minimum)
                {
                    minimum = item.EredmenyPerc;
                    leggyorsabb = item.Nev;
                }
                
            }

            MessageBox.Show($"A legjobb id� {minimum}");

            //(!)



        }
    }
}