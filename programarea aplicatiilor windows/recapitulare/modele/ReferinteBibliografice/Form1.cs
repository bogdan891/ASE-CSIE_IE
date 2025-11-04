using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ReferinteBibliografice
{
    public partial class Form1 : Form
    {
        List<Carte> publicatii = new List<Carte>();
        List<Autor> autori = new List<Autor>();
        string connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = SabinTarbaExamDB.accdb";
        Carte carteApasata = new Carte();

        public Form1()
        {
            InitializeComponent();
            this.autori.Add(new Autor("Sabin", "Gradul 1", 1));
            this.autori.Add(new Autor("Maria", "Gradul 2", 2));
            this.autori.Add(new Autor("Andrei", "Gradul 3", 3));

           
        }

        private void adaugaManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdaugaManual frm = new AdaugaManual(publicatii);
            frm.ShowDialog();

            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            this.publicatii.Sort((x, y) => x.Titlu.CompareTo(y.Titlu));

            foreach(Carte c in publicatii)
            {
                ListViewItem itm = new ListViewItem(c.Isbn);
                itm.SubItems.Add(c.Categorie);
                itm.SubItems.Add(c.Titlu);
                itm.SubItems.Add(c.Pret.ToString());

                listView1.Items.Add(itm);
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();

            foreach (Autor a in autori)
            {
                ListViewItem itm = new ListViewItem(a.Nume);
                itm.SubItems.Add(a.Grad_didactic);
                itm.SubItems.Add(a.Marca.ToString());
                

                listView2.Items.Add(itm);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            listView3.Items.Clear();

            try
            {
                conn.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.CommandText = "SELECT * FROM autori ORDER BY nume";
                comanda.Connection = conn;

                OleDbDataReader reader = comanda.ExecuteReader();

                while(reader.Read())
                {
                    string nume = reader["nume"].ToString();
                    string grad_didactic = reader["grad_didactic"].ToString();
                    int marca = Convert.ToInt32(reader["marca"].ToString());

                    //MessageBox.Show(nume + " " + grad_didactic + " " + marca);

                    ListViewItem itm = new ListViewItem(nume);
                    itm.SubItems.Add(grad_didactic);
                    itm.SubItems.Add(marca.ToString());

                    listView3.Items.Add(itm);
                }


            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem itm in listView3.Items)
                if(itm.Checked)
                {
                    Autor a = new Autor(itm.SubItems[0].Text, itm.SubItems[1].Text, Convert.ToInt32(itm.SubItems[2].Text));

                    this.autori.Add(a);
                }

            button2_Click(sender, e);
        }

        private void listView2_MouseDown(object sender, MouseEventArgs e)
        {
           

            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem itm = listView2.SelectedItems[0];

                listView2.DoDragDrop(itm, DragDropEffects.Copy | DragDropEffects.Move);
            }

        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            if (((e.KeyState & 8) == 8) && (e.AllowedEffect & DragDropEffects.Copy) ==
                    DragDropEffects.Copy)
                e.Effect = DragDropEffects.Copy;
            else
                if ((e.AllowedEffect & DragDropEffects.Move) ==
                    DragDropEffects.Move)
                e.Effect = DragDropEffects.Move;

        }


        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            ListViewItem item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

            Autor a = new Autor(item.SubItems[0].Text, item.SubItems[1].Text, Convert.ToInt32(item.SubItems[2].Text));

            carteApasata += a;

            textBox1.Text += a.Nume + Environment.NewLine;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();

            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem itm = listView1.SelectedItems[0];

                Carte carte = new Carte(itm.SubItems[0].Text, itm.SubItems[1].Text, itm.SubItems[2].Text, (float)Convert.ToDouble(itm.SubItems[2].Text));

                carteApasata = publicatii.Where(x => x.Isbn.Equals(carte.Isbn)).ToArray()[0];

                foreach (Autor a in carteApasata.Autori)
                    textBox1.Text += a.Nume + Environment.NewLine;

  
            }


        }

  

        private void graficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (publicatii.Count > 0)
            {
                int[] nrAutoriCarti = new int[this.publicatii.Count];

                for (int i = 0; i < this.publicatii.Count; i++)
                    nrAutoriCarti[i] = this.publicatii[i].Autori.Count;

                GraficForm frm = new GraficForm(nrAutoriCarti);
                frm.ShowDialog();
            }
            else MessageBox.Show("Nu sunt carti incarcate, asa ca nu pot trasa graficul!");
           

        }
    }
}
