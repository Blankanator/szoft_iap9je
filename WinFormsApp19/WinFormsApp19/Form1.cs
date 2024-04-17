using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace WinFormsApp19
{
    public partial class Form1 : Form
    {
        BindingList<Futó> futók = new();

        public Form1()
        {
            InitializeComponent();
            ////dataGridView1.DataSource = futók; ///!!!!!!!!!!!!!!
            ///
            futókBindingSource.DataSource = futók;
        }

        private void buttonBetöltés_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("futottakmeg.txt");
                var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
                var t = csv.GetRecords<Futó>();

                foreach (var item in t)
                {
                    futók.Add(item);
                }

                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonMentés_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                    var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                    csv.WriteRecords(futók);

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
            if (futókBindingSource.Current == null) return;

            if (MessageBox.Show("A", "B", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                futókBindingSource.RemoveCurrent();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormÚjFutócs formÚjFutócs = new FormÚjFutócs();
            formÚjFutócs.ÚjFutó = futókBindingSource.Current as Futó;

            formÚjFutócs.Show();

            //if (formÚjFutócs.ShowDialog() == DialogResult.OK)
            //{
            //    futókBindingSource.Add(formÚjFutócs.ÚjFutó);
            //}

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double minimum = double.PositiveInfinity;
            string leggyorsabb = string.Empty;

            foreach (var item in futók)
            {
                if (item.EredmenyPerc <minimum)
                {
                    minimum = item.EredmenyPerc;
                    leggyorsabb = item.Nev;
                }
                
            }

            MessageBox.Show($"A legjobb idõ {minimum}");

            //(!)



        }
    }
}