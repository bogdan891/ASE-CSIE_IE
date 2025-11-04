using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace model_angajati
{
    public partial class MainForm : Form
    {
        public static BindingList<Angajat> angajati = new BindingList<Angajat>();
        public static List<Companie> companii = new List<Companie>
{
    new Companie(1, "Google"),
    new Companie(2, "Microsoft"),
    new Companie(3, "Apple")
};
        public MainForm()
        {
            InitializeComponent();
            Upload();
            this.Load += MainForm_Load;
            lstAngajati.MouseDoubleClick += LstAngajati_MouseDoubleClick;
            angajati = new BindingList<Angajat>(angajati.OrderBy(x => x).ToList());
        }

        public void Upload()
        {
            string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Salariati;Integrated Security=True;Connect Timeout=30;";
            using(SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string query = "SELECT Nume, DataNasterii, IdCompanie FROM Angajati";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string Nume = reader.GetString(0);
                            DateTime DataNasterii = reader.GetDateTime(1);
                            int IdCompanie = Convert.ToInt32(reader.GetDecimal(2));
                            angajati.Add(new Angajat(Nume, DataNasterii, IdCompanie));
                        }
                    }
                }
            }
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            lstAngajati.Items.Clear();
            lstAngajati.View = View.Details;
            lstAngajati.MultiSelect = false;
            lstAngajati.HideSelection = false;
            lstAngajati.FullRowSelect = true;
            lstRefresh();
        }
        public void lstRefresh()
        {
            lstAngajati.Clear();
            if(lstAngajati.Items.Count == 0)
            {
                lstAngajati.Columns.Add("Nume", 100, HorizontalAlignment.Center);
                lstAngajati.Columns.Add("Data Nasterii", 100, HorizontalAlignment.Center);
                lstAngajati.Columns.Add("Companie", 100, HorizontalAlignment.Center);
            }

            foreach(var x in angajati)
            {
                ListViewItem item = new ListViewItem(x.Nume);
                item.SubItems.Add(x.DataNasterii.ToString());
                item.SubItems.Add(x.NumeCompanie);
                lstAngajati.Items.Add(item);
            }
            angajati = new BindingList<Angajat>(angajati.OrderBy(x => x).ToList());
        }

        private void adaugaAngajatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddEditAngajat();
            if(form.ShowDialog() == DialogResult.OK)
            {
                angajati.Add(form.angajat);
            }
            lstRefresh();
        }

        public void LstAngajati_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lstAngajati.SelectedItems[0].Index;
            Angajat angajatSelectat = angajati[index];
            var form = new AddEditAngajat(angajatSelectat);
            if (form.ShowDialog() == DialogResult.OK)
            {
                angajati[index].Nume = form.angajat.Nume;
                angajati[index].DataNasterii = form.angajat.DataNasterii;
                angajati[index].IdCompanie = form.angajat.IdCompanie;
            }
            lstRefresh();
        }

        private void salvareInXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Fisier XML|*.xml";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        XmlSerializer x = new XmlSerializer(typeof(BindingList<Angajat>));
                        x.Serialize(fs, angajati);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Eroare la salvare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stergeAngajatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = lstAngajati.SelectedItems[0].Index;
            Angajat angajatSelectat = angajati[index];
            var confirm = MessageBox.Show("Vrei sa stergi acest angajat?", "Sterge un angajat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);  
            if(confirm == DialogResult.Yes)
            {
                angajati.Remove(angajatSelectat);
            }
            lstRefresh();
        }
    }
}
