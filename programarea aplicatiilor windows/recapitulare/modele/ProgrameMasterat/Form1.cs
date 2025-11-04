using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrameMasterat
{
    public partial class Form1 : Form
    {
        List<ProgramStudiu> programe = new List<ProgramStudiu>();
        List<Candidat> candidati = new List<Candidat>();
        bool paint_it = false;
        const int margine = 10;
        const int marg = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(tbCodProgram.Text);
            string denumire = tbDenumire.Text;
            int buget = Convert.ToInt32(tbBuget.Text);
            int taxa = Convert.ToInt32(tbTaxa.Text);

            ProgramStudiu program = new ProgramStudiu(cod, denumire, buget, taxa);

            listBox1.Items.Add(program.CodProgram + " " + program.DenumireProgram + " " + program.NrLocuriBuget + " " + program.NrLocuriTaxa);

            programe.Add(program);

            tbCodProgram.Clear();
            tbDenumire.Clear();
            tbBuget.Clear();
            tbTaxa.Clear();

        }

        private void afisareCandidati()
        {
            listView1.Items.Clear();

            foreach (Candidat c in candidati)
            {
                ListViewItem itm = new ListViewItem(c.CodCandidat.ToString());
                itm.SubItems.Add(c.NumeCandidat);
                itm.SubItems.Add(c.MedieConcurs.ToString());

                string optiuni = "";
                for (int i = 0; i < c.VectorOptiuni.Length - 1; i++)
                    optiuni += c.VectorOptiuni[i] + ", ";

                optiuni += c.VectorOptiuni[c.VectorOptiuni.Length - 1];

                itm.SubItems.Add(optiuni);

                listView1.Items.Add(itm);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CandidatForm frm = new CandidatForm(candidati);
            frm.ShowDialog();

            afisareCandidati();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem itm = listView1.SelectedItems[0];

                int cod = Convert.ToInt32(itm.SubItems[0].Text);

                Candidat c = candidati.Where(x => x.CodCandidat == cod).ToArray()[0];

                var lbItemSelected = listBox1.SelectedItem;

                int codProgramSelectat = Convert.ToInt32(lbItemSelected.ToString().Split(' ')[0]);

                c += codProgramSelectat;

            }

            afisareCandidati();

        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem itm in listView1.SelectedItems)
                {
                    int cod = Convert.ToInt32(itm.SubItems[0].Text);

                    Candidat deSters = candidati.Where(x => x.CodCandidat == cod).ToArray()[0];
                    candidati.Remove(deSters);
                }
            }

            afisareCandidati();
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CandidatForm frm = new CandidatForm(new List<Candidat>());

            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem itm in listView1.SelectedItems)
                {
                    int cod = Convert.ToInt32(itm.SubItems[0].Text);
                    Candidat deModificat = candidati.Where(x => x.CodCandidat == cod).ToArray()[0];

                    frm.tbCod.Text = deModificat.CodCandidat.ToString();
                    frm.tbNume.Text = deModificat.NumeCandidat;
                    frm.tbMedie.Text = deModificat.MedieConcurs.ToString();
                    string optiuni = "";
                    for (int i = 0; i < deModificat.VectorOptiuni.Length - 1; i++)
                        optiuni += deModificat.VectorOptiuni[i] + ", ";

                    optiuni += deModificat.VectorOptiuni[deModificat.VectorOptiuni.Length - 1];

                    frm.tbOptiuni.Text = optiuni;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            int codNou = Convert.ToInt32(frm.tbCod.Text);
                            string nume = frm.tbNume.Text;
                            float medie = (float)Convert.ToDouble(frm.tbMedie.Text);

                            string[] valori = frm.tbOptiuni.Text.Split(',');

                            int[] optiuniNoi = new int[valori.Length];

                            for (int i = 0; i < valori.Length; i++)
                            {
                                optiuniNoi[i] = Convert.ToInt32(valori[i]);
                            }

                            deModificat.CodCandidat = codNou;
                            deModificat.NumeCandidat = nume;
                            deModificat.MedieConcurs = medie;
                            deModificat.VectorOptiuni = optiuniNoi;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            frm.tbCod.Clear();
                            frm.tbOptiuni.Clear();
                            frm.tbNume.Clear();
                            frm.tbMedie.Clear();
                        }

                    }
                }

                afisareCandidati();

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (paint_it == true)               
            {


                int[] vector = new int[5];
                vector[0] = 1;
                vector[1] = 2;
                vector[2] = 3;
                vector[3] = 4;
                vector[4] = 5;


                Pen pen = new Pen(new SolidBrush(Color.DarkBlue));

                Graphics gr = e.Graphics;

                Rectangle container = new Rectangle(panel1.ClientRectangle.X + margine, panel1.ClientRectangle.Y + 2 * margine,
                    panel1.ClientRectangle.Width - 2 * margine, panel1.ClientRectangle.Height - 3 * margine);

                gr.DrawRectangle(pen, container);

                double valMax = vector.Max();
                double latime = container.Width / vector.Length / 3;
                double distanta = (container.Width - vector.Length * latime) / (vector.Length + 1);

                Rectangle[] recs = new Rectangle[vector.Length];

                for (int i = 0; i < vector.Length; i++)
                {
                    recs[i] = new Rectangle((int)(container.Location.X + (i + 1) * distanta + i * latime),
                                            (int)(container.Location.Y + container.Height - vector[i] / valMax * container.Height),
                                            (int)latime,
                                            (int)(vector[i] / valMax * container.Height));

                    gr.FillRectangle(new SolidBrush(Color.Red), recs[i]);

                }

                //int[] vect = new int[5];
                //vect[0] = 1;
                //vect[1] = 2;
                //vect[2] = 3;
                //vect[3] = 4;
                //vect[4] = 5;

                //int nrElem = vect.Count();

                //Graphics gr = e.Graphics;
                //Rectangle rec = new Rectangle(panel1.ClientRectangle.X + marg,
                //    panel1.ClientRectangle.Y + 2 * marg,
                //    panel1.ClientRectangle.Width - 2 * marg,
                //    panel1.ClientRectangle.Height - 3 * marg);
                //Pen pen = new Pen(Color.Red, 3);
                //gr.DrawRectangle(pen, rec);

                //double latime = rec.Width / nrElem / 3;
                //double distanta = (rec.Width - nrElem * latime) / (nrElem + 1);
                //double valMax = vect.Max();

                //Brush br = new SolidBrush(Color.Green);
                //Rectangle[] recs = new Rectangle[nrElem];
                //for (int i = 0; i < nrElem; i++)
                //{
                //    recs[i] = new Rectangle((int)(rec.Location.X + (i + 1) * distanta + i * latime),
                //        (int)(rec.Location.Y + rec.Height - vect[i] / valMax * rec.Height),
                //        (int)latime,
                //        (int)(vect[i] / valMax * rec.Height));
                //    gr.FillRectangle(br, recs[i]);

                //}



            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            paint_it = true;
            panel1.Invalidate();
        }
    }
}
