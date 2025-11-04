using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace model_credit
{
    public partial class MainForm : Form
    {
        public BindingList<Credit> credite = new BindingList<Credit>();
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            dgvCredite.DoubleClick += DgvCredite_DoubleClick;
            printDoc.PrintPage += PrintDoc_PrintPage;
            preview.Document = printDoc;
        }

        public void citireCredit()
        {
            string caleFisier = Path.Combine(Application.StartupPath, "credite.txt");
            if (File.Exists(caleFisier))
            {
                string[] linii = File.ReadAllLines(caleFisier);
                foreach (string linie in linii)
                {
                    string[] parte = linie.Split(';');
                    if (parte.Length == 5)
                    {
                        try
                        {
                            string client = parte[0];
                            double valoare = double.Parse(parte[1]);
                            double dobanda = double.Parse(parte[2]);
                            DateTime data = DateTime.Parse(parte[3]);
                            int perioada = int.Parse(parte[4]);

                            credite.Add(new Credit(client, valoare, dobanda, data, perioada));
                        }
                        catch
                        {
                            MessageBox.Show("Eroare la conversia unei linii din fișier.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Fișierul 'credite.txt' nu a fost găsit în folderul aplicației.", "Fișier lipsă", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void MainForm_Load(object sender, EventArgs e)
        {
            dgvCredite.AutoGenerateColumns = true;
            dgvCredite.MultiSelect = false;
            dgvCredite.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCredite.AllowUserToAddRows = false;
            dgvCredite.ReadOnly = true;
            dgvCredite.RowHeadersVisible = false;

            citireCredit();

            dgvCredite.DataSource = credite;
            dgvCredite.ClearSelection();
        }

        private void adaugareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddEditCredit();
            if(form.ShowDialog() == DialogResult.OK)
            {
                credite.Add(form.credit);
                dgvCredite.Refresh();
            }
        }

        public void DgvCredite_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCredite.SelectedRows.Count == 0) return;

            int index = dgvCredite.SelectedRows[0].Index;

            var edit = MessageBox.Show("Doriti sa editati acest client?", "Editare date client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (edit == DialogResult.Yes)
            {
                var form = new AddEditCredit(credite[index]);
                if(form.ShowDialog() == DialogResult.OK)
                {
                    credite[index] = form.credit;
                }
                dgvCredite.Refresh();
            }
            else
            {
                var delete = MessageBox.Show("Doriti sa stergeti acest client?", "Stergere date client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (delete == DialogResult.Yes)
                {
                    credite.RemoveAt(index);
                    dgvCredite.Refresh();
                }
            }
        }

        public void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Times New Roman", 12);

            int x = 100, y = 100;

            e.Graphics.DrawString("Lista clientilor care beneficiaza de credit: ", new Font("Verdana", 14, FontStyle.Bold), Brushes.DarkBlue, x, y);
            y += 45;

            foreach( var credit in credite )
            {
                e.Graphics.DrawString(credit.ToString(), font, Brushes.Black, x, y);
                y += 25;
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preview.ShowDialog();
        }
    }
}
