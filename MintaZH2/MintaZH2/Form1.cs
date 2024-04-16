using CsvHelper;
using System.ComponentModel;
using System.Diagnostics.PerformanceData;
using System.Globalization;
using System.Windows.Forms.Design;

namespace MintaZH2
{
    public partial class Form1 : Form
    {
        BindingList<FutokData> futokList = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            futokDataBindingSource.DataSource = futokList;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("futoversenyzok.csv");
            var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
            var tomb = csv.GetRecords<FutokData>();

            foreach (var item in tomb)
            {
                futokList.Add(item);
            }

            sr.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(sfd.FileName);
                    var csv = new CsvWriter(sw, CultureInfo.InvariantCulture);
                    csv.WriteRecords(futokList);

                    sw.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Valami hiba történt, valószínüleg hibás a forrásfájl!", "Hiba", MessageBoxButtons.OK) == DialogResult.OK;
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (futokDataBindingSource.Current == null)
            {
                MessageBox.Show("Hiba történt, nincs kijelölt sor!");
                return;
            }

            if (MessageBox.Show("Biztosan tölrölni szeretné a sort?","Megerõsítés szükséges", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                futokDataBindingSource.RemoveCurrent();
            }
            
        }

        private void newlineButton_Click(object sender, EventArgs e)
        {
            FormAddNew fad = new FormAddNew();
            if (fad.ShowDialog() == DialogResult.OK)
            {
                futokList.Add(fad.EditedFutokData);
            }

        }
    }
}