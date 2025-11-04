using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Firme
{
    public partial class Form1 : Form
    {
        ContainerProduse produse = new ContainerProduse(new List<Produs>());
        bool paint_it = false;
        const int margine = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdaugaProdus frm = new AdaugaProdus(produse);
            frm.ShowDialog();
            afiseazaProduse();
        }

        private void afiseazaProduse()
        {
            listView1.Items.Clear();

            foreach(Produs p in produse.Produse)
            {
                ListViewItem itm = new ListViewItem(p.Cod.ToString());
                itm.SubItems.Add(p.Denumire);
                itm.SubItems.Add(p.Pret.ToString());

                listView1.Items.Add(itm);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                ListViewItem itm = listView1.SelectedItems[0];

                int cod = Convert.ToInt32(itm.SubItems[0].Text);

                ModificaProdus frm = new ModificaProdus(this.produse.Produse.Where(x => x.Cod == cod).ToArray()[0]);
                frm.ShowDialog();
            }

            afiseazaProduse();
        }

        private void serializeazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string delimitator = ",";
            dlg.Filter = "(*.txt)|*.txt";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(dlg.FileName);
                
                
                StringBuilder sb = new StringBuilder();

                foreach(ListViewItem itm in listView1.Items)
                {
                    sb.Append(itm.SubItems[0].Text).Append(delimitator);
                    sb.Append(itm.SubItems[1].Text).Append(delimitator);
                    sb.Append(itm.SubItems[2].Text).Append("\n");

                }

                sw.Write(sb.ToString());


                sw.Close();
            }


            listView1.Items.Clear();
            this.produse.Produse.Clear();



            MessageBox.Show("Date salvata in fisier TXT!");
        }

        private void deserializeazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "(*.txt)|*.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(dlg.FileName);
                
                
                
                 string date = sr.ReadToEnd();
                 string[] valori = date.Split(',');

                 for(int i = 0; i < valori.Length; i+=3)
                 {
                    int cod = Convert.ToInt32(valori[i]);
                    string denumire = valori[i+1];
                    float pret = (float)Convert.ToDouble(valori[i+2]);

                    produse.Produse.Add(new Produs(cod, denumire, pret));
                }
     
                
                sr.Close();
            }


            
            afiseazaProduse();
            



            MessageBox.Show("Date incarcate din fisier TXT!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Produs produsPretMinim = produse.Produse[0];

            foreach(Produs p in produse.Produse)
                if(p < produsPretMinim)
                    produsPretMinim = p;

            MessageBox.Show(produsPretMinim.ToString());
            textBox1.Text = "[PRODUS PRET MINIM] " + produsPretMinim.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if(paint_it == true && listView1.SelectedItems.Count > 0)
            {
                Graphics gr = e.Graphics;
                Rectangle container = new Rectangle(panel1.ClientRectangle.X + margine, panel1.ClientRectangle.Y + 2 * margine,
                    panel1.ClientRectangle.Width - 2 * margine, panel1.ClientRectangle.Height - 3 * margine);
                gr.DrawRectangle(new Pen(new SolidBrush(Color.Red)), container);

                Produs produsPretMinim = produse.Produse[0];

                foreach (Produs p in produse.Produse)
                    if (p < produsPretMinim)
                        produsPretMinim = p;

                float pretMin = produsPretMinim.Pret;
                float pretRandom = (float)Convert.ToDouble(listView1.SelectedItems[0].SubItems[2].Text);

                if (pretMin != pretRandom)
                {
                    Rectangle cercProdusPretMin = new Rectangle(container.Location.X + container.Width / 2 - 50, container.Location.Y + container.Height / 2 - 50,
                                                    (int)(pretMin / 2), (int)(pretMin / 2));

                    Rectangle cercProdusPretOarecare = new Rectangle(container.Location.X + container.Width / 2 - 50 - cercProdusPretMin.Width / 2, container.Location.Y + container.Height / 2 - 50 - cercProdusPretMin.Height / 2,
                                                        (int)(pretRandom / 2), (int)(pretRandom / 2));

                    gr.DrawEllipse(new Pen(new SolidBrush(Color.Green)), cercProdusPretMin);
                    gr.DrawEllipse(new Pen(new SolidBrush(Color.Blue)), cercProdusPretOarecare);

                }
                else MessageBox.Show("Nu are sens sa desenez 2 cercuri suprapuse: [ati selectat fix item-ul corespunzator produsului cu pretul minim!]");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            paint_it = true;
            panel1.Invalidate();
        }
    }
}
