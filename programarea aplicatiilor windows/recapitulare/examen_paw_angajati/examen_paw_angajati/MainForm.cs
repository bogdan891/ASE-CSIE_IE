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
using System.Xml.Serialization;

namespace examen_paw_angajati
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            listAngajati.MouseDoubleClick += listAngajati_MouseDoubleClick;
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            listAngajati.Items.Clear();
            listAngajati.View = View.Details;
            listAngajati.FullRowSelect = true;
            listAngajati.MultiSelect = false;
            listAngajati.HideSelection = false;

            if(listAngajati.Items.Count == 0)
            {
                listAngajati.Columns.Add("Nume", 150, HorizontalAlignment.Center);
                listAngajati.Columns.Add("Data Nasterii", 100, HorizontalAlignment.Center);
                listAngajati.Columns.Add("ID Companie", 100, HorizontalAlignment.Center);
            }

            foreach (var x in FakeDatabase.angajati.OrderBy(a => a))
            {
                Companie companie = FakeDatabase.companii.FirstOrDefault(c => c.Id == x.IDCompanie);
                string numeCompanie = companie != null ? companie.Nume : "Necunoscut";

                ListViewItem item = new ListViewItem(x.Nume);
                item.SubItems.Add(x.DataNasterii.ToString("dd-MM-yyyy"));
                item.SubItems.Add(numeCompanie);
                item.Tag = x;
                listAngajati.Items.Add(item);

            }
        }

        public void RefreshListView()
        {
            listAngajati.Items.Clear();
            listAngajati.View = View.Details;
            listAngajati.FullRowSelect = true;
            listAngajati.MultiSelect = false;
            listAngajati.HideSelection = false;

            foreach (var x in FakeDatabase.angajati.OrderBy(a => a))
            {
                Companie companie = FakeDatabase.companii.FirstOrDefault(c => c.Id == x.IDCompanie);
                string numeCompanie = companie != null ? companie.Nume : "Necunoscut";

                ListViewItem item = new ListViewItem(x.Nume);
                item.SubItems.Add(x.DataNasterii.ToString("dd-MM-yyyy"));
                item.SubItems.Add(numeCompanie);
                item.Tag = x;
                listAngajati.Items.Add(item);

            }
        }

        private void adaugaAngajatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddEdit f = new FormAddEdit();
            if (f.ShowDialog() == DialogResult.OK)
            {
                FakeDatabase.angajati.Add(f.angajatAdaugatEditat);
                RefreshListView();
            }
        }

        public void listAngajati_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listAngajati.SelectedItems.Count > 0)
            {
                ListViewItem item = listAngajati.SelectedItems[0];
                Angajat angajatSelectat = (Angajat)item.Tag;

                FormAddEdit f = new FormAddEdit(angajatSelectat);

                if (f.ShowDialog() == DialogResult.OK)
                {
                    RefreshListView();
                }
            }
        }

        private void stergeAngajatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listAngajati.SelectedItems.Count > 0)
            {
                int index = listAngajati.SelectedItems[0].Index;
                DialogResult confirm  = MessageBox.Show(
                    "Doriti sa stergeti acest angajat?",
                    "Confirmare stergere!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning );
                if (confirm == DialogResult.Yes)
                {
                    FakeDatabase.angajati.RemoveAt(index);
                    RefreshListView();
                }
            }
            else
            {
                MessageBox.Show("Selectati un angajat pentru stergere!");
            }
        }

        private void asociereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lipsa = FakeDatabase.angajati.Where(x => !(bool)x).ToList();
            if(lipsa.Count == 0)
            {
                MessageBox.Show("Toti angajatii au o companie asociata!", "Verificare totala!", MessageBoxButtons.OK);
            }
            else
            {
                string mesaj = "Următorii angajați NU au companie:\n\n" + string.Join("\n", lipsa.Select(a => a.Nume));
                MessageBox.Show(mesaj, "Angajați fără companie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void salvareRaportXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Fisier XML|*.xml";
            saveFileDialog.Title = "Salveaza angajati in format XML";
            saveFileDialog.FileName = "angajati.xml";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    salveazaInXML(saveFileDialog.FileName);
                    MessageBox.Show("Raportul a fost realizat!", "Succes!", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la realizarea raportului" + ex.Message, 
                        "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static void salveazaInXML(string filename)
        {
            XmlSerializer x = new XmlSerializer(typeof(BindingList<Angajat>));
            using(StreamWriter sw = new StreamWriter(filename))
            {
                x.Serialize(sw, FakeDatabase.angajati);
            }
        }
    }
}
