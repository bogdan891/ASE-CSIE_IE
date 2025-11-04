using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace model_bicicleta
{
    public partial class MainForm : Form
    {
        public static List<Bicicleta> biciclete = new List<Bicicleta>
{
    new Bicicleta(1001, "Piata Unirii", 10),
    new Bicicleta(1002, "Gara de Nord", 25),
    new Bicicleta(1003, "Piata Romana", 18),
    new Bicicleta(1004, "Universitate", 30),
    new Bicicleta(1005, "Parcul Herastrau", 25)
};

        public static List<Utilizator> utilizatori = new List<Utilizator>
{
    new Utilizator("Andrei Ionescu", 1001, 15),
    new Utilizator("Maria Georgescu", 1002, 45),   // peste 30
    new Utilizator("Radu Popa", 1001, 32),         // peste 30
    new Utilizator("Ana Dumitru", 1003, 25),
    new Utilizator("Cristina Vlad", 1001, 50),     // peste 30
    new Utilizator("Ion Stoica", 1002, 18),
    new Utilizator("Laura Enache", 1004, 22),
    new Utilizator("Mihai Tudor", 1003, 38),       // peste 30
    new Utilizator("Bianca Nistor", 1001, 9),
    new Utilizator("Vlad Marinescu", 1005, 60)     // peste 30
};

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            lvB.SelectedIndexChanged += LvB_SelectedIndexChanged;
            printDoc.PrintPage += PrintDoc_PrintPage;
            preview.Document = printDoc;
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            lvB.Items.Clear();
            lvU.Items.Clear();

            lvB.View = View.Details;
            lvB.MultiSelect = false;
            lvB.FullRowSelect = true;
            lvB.HideSelection = false;

            lvU.View = View.Details;
            lvU.MultiSelect = false;
            lvU.FullRowSelect = true;
            lvU.HideSelection = false;

            lvBRefresh();
        }

        public void lvBRefresh()
        {
            if (lvB.Items.Count == 0)
            {
                lvB.Columns.Add("COD", 110, HorizontalAlignment.Center);
                lvB.Columns.Add("STATIE", 110, HorizontalAlignment.Center);
                lvB.Columns.Add("KM PARCURSI", 110, HorizontalAlignment.Center);
            }

            foreach (var x in biciclete)
            {
                var item = new ListViewItem(x.CodB.ToString());
                item.SubItems.Add(x.StatieParcare);
                item.SubItems.Add(x.KmParcursi.ToString());

                lvB.Items.Add(item);
            }
        }

        public void lvURefresh(int cod)
        {
            if (lvU.Items.Count == 0)
            {
                lvU.Columns.Add("NUME", 110, HorizontalAlignment.Center);
                lvU.Columns.Add("COD BICICLETA", 110, HorizontalAlignment.Center);
                lvU.Columns.Add("DURATA UTILIZARE", 110, HorizontalAlignment.Center);
            }

            foreach (var x in utilizatori.Where(u => u.CodB == cod))
            {
                var item = new ListViewItem(x.Nume);
                item.SubItems.Add(x.CodB.ToString());
                item.SubItems.Add(x.DurataUtilizare.ToString());

                lvU.Items.Add(item);
            }
        }

        public void LvB_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvU.Clear();
            lvU.Items.Clear();
            if(lvB.SelectedItems.Count > 0)
            {
                int cod = int.Parse(lvB.SelectedItems[0].SubItems[0].Text);
                lvURefresh(cod);
                var lst = utilizatori.Where(u => u.CodB == cod);
                double suma = 0;
                foreach ( var x in lst)
                {
                    if(x.DurataUtilizare > 30)
                    {
                        int minPeste30 = x.DurataUtilizare - 30;
                        int interval10 = (int)Math.Round(minPeste30 / 10.0);
                        suma += interval10 * 2;
                    }
                }
                txtSuma.Text = $"Total incasari pt B{cod.ToString()} = {suma.ToString()}";
            }
        }

        public void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Times New Roman", 12);
            e.Graphics.DrawString("Situatia arondarii Bicicletelor", new Font("Verdana", 14, FontStyle.Bold), Brushes.DarkBlue, 100, 100);
            int x = 100, y = 130;

            foreach(var b in biciclete)
            {
                e.Graphics.DrawString($"Utilizatorii bicicletei {b.CodB.ToString()}", font, Brushes.Blue, x, y);
                y += 25;
                foreach(var u in utilizatori.Where(ut => ut.CodB == b.CodB))
                {
                    e.Graphics.DrawString($" -> {u.Nume}", font, Brushes.Black, x, y);
                    y += 25;
                }
                y += 5;
            }
        }
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preview.Show();
        }

        private void serializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs1 = new FileStream("biciclete.bin", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs1, biciclete);
                }

                using (FileStream fs2 = new FileStream("utilizatori.bin", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs2, utilizatori);
                }

                MessageBox.Show("Serializare completă!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la serializare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
