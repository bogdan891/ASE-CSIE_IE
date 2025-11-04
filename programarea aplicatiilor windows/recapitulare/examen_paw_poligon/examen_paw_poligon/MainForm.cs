using examen_paw_poligon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace examen_paw_poligon
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // setări ListView o singură dată
            lstPoligoane.View = View.Details;
            lstPoligoane.FullRowSelect = true;
            lstPoligoane.MultiSelect = false;
            lstPoligoane.HideSelection = false;

            lstPoligoane.Columns.Add("Cod Figura", 90);
            lstPoligoane.Columns.Add("Grosime Linie", 90);
            lstPoligoane.Columns.Add("Eticheta", 120);
            lstPoligoane.Columns.Add("Culoare", 90);

            Load += MainForm_Load;                       // populate la start
            lstPoligoane.DoubleClick += lstPoligoane_DoubleClick;
        }

        //–––––––––––––  Încărcare iniţială  –––––––––––
        private void MainForm_Load(object sender, EventArgs e)
        {
            lstPoligoane.Items.Clear();
            foreach (var fig in FakeDatabase.figuri)
            {
                var itm = new ListViewItem(fig.CodFigura.ToString());
                itm.SubItems.Add(fig.GrosimeLinie.ToString());
                itm.SubItems.Add(fig.Eticheta);
                itm.SubItems.Add(fig.Culoare.Name);
                lstPoligoane.Items.Add(itm);
            }
        }

        //–––––––––––––  Adăugare  –––––––––––
        private void adaugareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormAddEdit f = new FormAddEdit())
            {
                if (f.ShowDialog() != DialogResult.OK) return;

                Poligon p = f.PoligonCreat;
                FakeDatabase.figuri.Add(p);

                ListViewItem itm = new ListViewItem(p.CodFigura.ToString());
                itm.SubItems.Add(p.GrosimeLinie.ToString());
                itm.SubItems.Add(p.Eticheta);
                itm.SubItems.Add(p.Culoare.Name);
                lstPoligoane.Items.Add(itm);
            }
        }

        //–––––––––––––  Editare (dublu‑click)  –––––––––––
        private void lstPoligoane_DoubleClick(object sender, EventArgs e)
        {
            if (lstPoligoane.SelectedItems.Count == 0) return;
            int idx = lstPoligoane.SelectedItems[0].Index;

            var f = new FormAddEdit(FakeDatabase.figuri[idx]);
            if (f.ShowDialog() != DialogResult.OK) return;

            FakeDatabase.figuri[idx] = f.PoligonCreat;
            var p = f.PoligonCreat;

            var row = lstPoligoane.Items[idx];
            row.SubItems[0].Text = p.CodFigura.ToString();
            row.SubItems[1].Text = p.GrosimeLinie.ToString();
            row.SubItems[2].Text = p.Eticheta;
            row.SubItems[3].Text = p.Culoare.Name;
        }

        //–––––––––––––  Ştergere  –––––––––––
        private void stergereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstPoligoane.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selectează mai întâi un poligon din listă!");
                return;
            }
            if (MessageBox.Show("Sigur vrei să ştergi?", "Confirmare", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            int idx = lstPoligoane.SelectedItems[0].Index;
            FakeDatabase.figuri.RemoveAt(idx);
            lstPoligoane.Items.RemoveAt(idx);
        }

        //–––––––––––––  Serializare  –––––––––––
        private void serializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Fișiere binare (*.bin)|*.bin",
                Title = "Salvați colecția într-un fișier binar"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, FakeDatabase.figuri);
                    }
                    MessageBox.Show("Colecţia a fost salvată.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la salvare:\n" + ex.Message);
                }
            }
        }

        //–––––––––––––  Deserializare  –––––––––––
        private void deserializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Fișiere binare (*.bin)|*.bin",
                Title = "Încărcaţi colecţia din fişier"
            })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        var listaNoua = (BindingList<Poligon>)bf.Deserialize(fs);   // merge direct
                        FakeDatabase.figuri.Clear();
                        foreach (var p in listaNoua) FakeDatabase.figuri.Add(p);
                    }

                    // reîncarcă ListView-ul
                    lstPoligoane.Items.Clear();
                    foreach (var fig in FakeDatabase.figuri)
                    {
                        var itm = new ListViewItem(fig.CodFigura.ToString());
                        itm.SubItems.Add(fig.GrosimeLinie.ToString());
                        itm.SubItems.Add(fig.Eticheta);
                        itm.SubItems.Add(fig.Culoare.Name);
                        lstPoligoane.Items.Add(itm);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la încărcare:\n" + ex.Message);
                }
            }
        }

        private void perimetruTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float p = 0;
            foreach(var x in FakeDatabase.figuri)
            {
                p += x.CalculPerimetru();
            }
            MessageBox.Show("Perimetrul total al poligoanelor din colectie este " + p.ToString());
        }
    }
}
