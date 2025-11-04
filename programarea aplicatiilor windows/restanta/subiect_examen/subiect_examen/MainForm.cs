using subiect_examen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace subiect_examen
{
    public partial class MainForm : Form
    {
        private List<Tren> trenuri = new List<Tren>();
        private List<Vagon> vagoaneDisponibile = new List<Vagon>();
        private BindingList<Tren> trenuriBind;
        public MainForm()
        {
            InitializeComponent();
            trenuriBind = new BindingList<Tren>(trenuri);
            dgvTrenuri.DataSource = trenuriBind;
            printDoc.PrintPage += PrintDoc_PrintPage;
            printPreview.Document = printDoc;
            this.Load += MainForm_Load;
        }

        //Initializare DataGridView
        public void MainForm_Load(object sender, EventArgs e)
        {
            dgvTrenuri.ClearSelection();
            dgvTrenuri.AutoGenerateColumns = false;
            dgvTrenuri.Columns.Clear();

            // Coloane bind-uite
            dgvTrenuri.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nr Tren",
                DataPropertyName = "NrTren",
                ReadOnly = true
            });
            dgvTrenuri.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ruta",
                DataPropertyName = "Ruta"
            });
            dgvTrenuri.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cerere Bilete",
                DataPropertyName = "CerereBilete",
                ReadOnly = true
            });

            // Coloana calculată: Locuri Libere
            dgvTrenuri.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Locuri Libere",
                Name = "LocuriLibere",
                ReadOnly = true
            });

            this.dgvTrenuri.CellFormatting += dgvTrenuri_CellFormatting;
        }

        private void dgvTrenuri_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTrenuri.Columns[e.ColumnIndex].Name == "LocuriLibere")
            {
                Tren tren = dgvTrenuri.Rows[e.RowIndex].DataBoundItem as Tren;
                if (tren != null)
                {
                    e.Value = tren.LocuriRamase;
                }
            }
        }

        //Citirea vagaonelor din fisier text
        public List<Vagon> CitireVagoane(string fileName)
        {
            var list = new List<Vagon>();   
            foreach(var line in File.ReadAllLines(fileName))
            {
                var p = line.Split(',');
                int id = int.Parse(p[0]);
                int capacitate = int.Parse(p[1]);
                list.Add(new Vagon(id, capacitate));
            }
            return list;
        }

        //Generare Trenuri
        public List<Tren> GenerareTren(int nrTrenuri)
        {
            var list = new List<Tren>();
            string[] rute = {"Bucuresti Nord -> Cluj-Napoca", "Iasi -> Timisoara Nord", "Constanta -> Brasov", "Arad -> Mangalia", "Sibiu -> Bacau"};
            Random random = new Random();

            for(int i = 0; i < nrTrenuri; i++)
            {
                int nr = i + 500;
                string nrTren = $"IC{nr}";
                string ruta = rute[random.Next(rute.Length)];
                int cerere = random.Next(100, 250);

                list.Add(new Tren(nrTren, ruta, cerere));
            }
            return list;
        }

        //Alocare vagoane
        public void AlocaVagoane(List<Tren> trenuri, List<Vagon> vagoaneDisponibile)
        {
            foreach (var tren in trenuri)
            {
                int cerere = tren.CerereBilete;

                foreach (var vagon in vagoaneDisponibile.OrderByDescending(v => v.Capacitate).ToList())
                {
                    if (cerere > 0)
                    {
                        tren.Vagoane.Add(vagon);
                        cerere -= vagon.Capacitate;
                        vagoaneDisponibile.Remove(vagon);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        //Generare tren
        private void generareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trenuri.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Fișiere text (*.txt)|*.txt";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            vagoaneDisponibile = CitireVagoane(ofd.FileName);
            trenuri.AddRange(GenerareTren(5));
            AlocaVagoane(trenuri, vagoaneDisponibile);
            trenuriBind.ResetBindings();
            dgvTrenuri.ClearSelection();
        }

        //Stergere tren
        private void stergereTrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvTrenuri.CurrentRow != null && dgvTrenuri.CurrentRow.DataBoundItem is Tren tren)
            {
                var confirm = MessageBox.Show("Esti sigur ca vrei sa stergi acest tren?", "Stergere Tren", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    trenuriBind.Remove(tren);
                    trenuri.Remove(tren);
                    dgvTrenuri.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Selecteaza mai intai un tren pentru a stergere!", "Atentionare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void serializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Fișier binar (*.bin)|*.bin";
            sfd.Title = "Salvează trenurile";

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, trenuri);
                }
                MessageBox.Show("Lista de trenuri a fost serializate cu succes!", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Print Preview
        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = 100, y = 100;
            Font font = new Font("Times New Roman", 12);
            e.Graphics.DrawString("Lista trenurilor operate", new Font("Verdana", 14, FontStyle.Bold), Brushes.Black, x, y);
            y += 30;
            foreach(var t in trenuri)
            {
                string line = t.ToString();
                e.Graphics.DrawString(line, font, Brushes.Black, x, y);
                y += 25;
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreview.ShowDialog();
        }
    }
}
