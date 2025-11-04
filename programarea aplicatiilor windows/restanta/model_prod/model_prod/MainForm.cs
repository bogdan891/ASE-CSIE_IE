using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace model_prod
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            lstProduse.MouseDoubleClick += Mouse_DoubleClick;
            printDoc.PrintPage += printDoc_PrintPage;
            pPD.Document = printDoc;
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            lstProduse.Items.Clear();
            lstProduse.View = View.Details;
            lstProduse.MultiSelect = false;
            lstProduse.HideSelection = false;

            ListViewRefresh();
        }

        public void ListViewRefresh()
        {
            lstProduse.Clear();
            if (lstProduse.Columns.Count == 0)
            {
                lstProduse.Columns.Add("Cod Produs", 100, HorizontalAlignment.Center);
                lstProduse.Columns.Add("Denumire Produs", 150, HorizontalAlignment.Center);
                lstProduse.Columns.Add("Pret unitar", 100, HorizontalAlignment.Center);
            }

            foreach (var produs in FakeDatabase.produse)
            {
                ListViewItem item = new ListViewItem(produs.Cod.ToString());
                item.SubItems.Add(produs.Denumire);
                item.SubItems.Add(produs.Pret.ToString("0.00"));
                lstProduse.Items.Add(item);
            }
        }

        private void adaugaProdusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddEditForm();
            if(form.ShowDialog() == DialogResult.OK)
            {
                FakeDatabase.produse.Add(form.produs);
                ListViewRefresh();
            }
        }

        private void Mouse_DoubleClick(object sender, EventArgs e)
        {
            if(lstProduse.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selectează un produs pentru editare.");
                return;
            }
            int index = lstProduse.SelectedItems[0].Index;
            Prod prod = FakeDatabase.produse[index];
            var form = new AddEditForm(prod);
            if(form.ShowDialog() == DialogResult.OK)
            {
                FakeDatabase.produse[index] = form.produs;
                ListViewRefresh();
            }
        }

        private void serializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Fisier Binar|*.bin";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, FakeDatabase.produse);
                    }

                    MessageBox.Show("Serializare realizata cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deserializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Fisier Binar|*.bin";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        FakeDatabase.produse.Clear();
                        FakeDatabase.produse = (BindingList<Prod>)bf.Deserialize(fs);
                        ListViewRefresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pretulMinimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prod min = FakeDatabase.produse[0];
            foreach(var x in FakeDatabase.produse)
            {
                if(min.Pret > x.Pret)
                {
                    min = x;
                }
            }

            MessageBox.Show("Produsul cu pret minim este: " + min.ToString());
        }

        public void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Times New Roman", 12);
            int x = 100, y = 10;
            e.Graphics.DrawString("Meniu:", new Font("Cambria", 14, FontStyle.Bold), Brushes.Green, x, y);
            y += 40;
            foreach(var p in FakeDatabase.produse)
            {
                string line = p.ToString();
                e.Graphics.DrawString(line, font, Brushes.Black, x, y);
                y += 25;
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pPD.ShowDialog();
        }

        private void salvareInBazaDeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connection = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = GestiuneProduse; Integrated Security = True; Connect Timeout = 30;";
            using(SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                foreach(var prod in FakeDatabase.produse)
                {
                    string query = "INSERT INTO Produse VALUES(@cod, @denumire, @pret)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cod", prod.Cod);
                    cmd.Parameters.AddWithValue("@denumire", prod.Denumire);
                    cmd.Parameters.AddWithValue("@pret", prod.Pret);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Datele au fost salvate in baza de date cu succes!");
            }
        }
    }
}
