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

namespace examen_paw_prod
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }
        public void MainForm_Load(object sender, EventArgs e)
        {
            lstProduse.Items.Clear();
            lstProduse.View = View.Details;
            lstProduse.FullRowSelect = true;
            lstProduse.MultiSelect = false;
            lstProduse.HideSelection = false;
            if (lstProduse.Items.Count == 0)
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

        public void ListViewRefresh()
        {
            lstProduse.Items.Clear();
            lstProduse.View = View.Details;
            lstProduse.FullRowSelect = true;
            lstProduse.MultiSelect = false;
            lstProduse.HideSelection = false;
            if (lstProduse.Items.Count == 0)
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

        private void adaugareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddEdit form = new FormAddEdit();
            if (form.ShowDialog() == DialogResult.OK)
            {
                FakeDatabase.produse.Add(form.produsAdaugatEditat);
                ListViewRefresh();
            }
        }

        private void editareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstProduse.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selectează un produs pentru editare.");
                return;
            }

            int index = lstProduse.SelectedItems[0].Index;
            Prod produs = FakeDatabase.produse[index];

            FormAddEdit form = new FormAddEdit(produs);
            if (form.ShowDialog() == DialogResult.OK)
            {
                FakeDatabase.produse[index] = form.produsAdaugatEditat;
                ListViewRefresh();
            }
        }

        private void serializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Fisier binar|*.bin";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, FakeDatabase.produse);
                    }

                    MessageBox.Show("Serializare reușită!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la serializare: " + ex.Message);
                }
            }
        }

        private void deserializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fisier binar|*.bin";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        object rezultat = bf.Deserialize(fs);

                        BindingList<Prod> produseDeserializate = rezultat as BindingList<Prod>;
                        if (produseDeserializate == null)
                        {
                            MessageBox.Show("Fișierul nu conține o listă validă de produse.");
                            return;
                        }

                        int adaugate = 0;
                        foreach (var produs in produseDeserializate)
                        {
                            bool existaDeja = FakeDatabase.produse.Any(p => p.Cod == produs.Cod);
                            if (!existaDeja)
                            {
                                FakeDatabase.produse.Add(produs);
                                adaugate++;
                            }
                        }

                        MessageBox.Show($"S-au adăugat {adaugate} produse noi.", "Deserializare completă", MessageBoxButtons.OK);
                        ListViewRefresh();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la deserializare: " + ex.Message + "\n\n" + ex.StackTrace, "Eroare!");
                }
            }
        }
        private void pretulMinimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FakeDatabase.produse.Count == 0)
            {
                MessageBox.Show("Nu există produse în baza de date.");
                return;
            }

            int c = 0;
            string nume = "";
            float min = float.MaxValue;

            foreach (var x in FakeDatabase.produse)
            {
                if (x.Pret < min)
                {
                    min = x.Pret;
                    nume = x.Denumire;
                    c = x.Cod;
                }
            }

            Prod p = new Prod(c, nume, min);
            MessageBox.Show($"Cel mai ieftin produs disponibil este:\n{p}");
        }
    }
}