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
using System.Drawing.Printing;

namespace CosCumparaturi
{
    public partial class Form1 : Form
    {
        ContainerProduse vector = new ContainerProduse();

        public Form1()
        {
            InitializeComponent();
        }


        private void afisareProduse()
        {
            listView1.Items.Clear();

            Produs[] produse = vector.Produse;

            for(int i = 0; i < vector.Produse.Length; i++)
            {
                ListViewItem itm = new ListViewItem(produse[i].Id_produs.ToString());
                itm.SubItems.Add(produse[i].Denumire);
                itm.SubItems.Add(produse[i].Cantitate.ToString());
                itm.SubItems.Add(produse[i].Pret.ToString());
                itm.SubItems.Add(produse[i].Valoare.ToString());

                listView1.Items.Add(itm);
            }
        }
        private void adaugaProdusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdaugaProdu frm = new AdaugaProdu();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int id = Convert.ToInt32(frm.tbCod.Text);
                    string denumire = frm.tbDenumire.Text;
                    int cantitate = Convert.ToInt32(frm.tbCantitate.Text);
                    float pret = (float)Convert.ToDouble(frm.tbPret.Text);

                    Produs p = new Produs(id, denumire, cantitate, pret);

                    MessageBox.Show(p.ToString());

                    vector += p;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    afisareProduse();
                }


            }
        }

        private Produs[] stergeElement(Produs[] vector, int index)
        {
            Produs[] result;

            if(vector.Length == 1)
            {
                result = new Produs[] {};
            }
            else if(index == 0)
            {
                result = new Produs[vector.Length - 1];

                for (int i = 1; i < vector.Length; i++)
                    result[i-1] = vector[i];
            }
            else
            {
                result = new Produs[vector.Length - 1];

                for (int i = 0; i < index; i++)
                    result[i] = vector[i];

                for (int i = index + 1; i < vector.Length; i++)
                    result[i] = vector[i];
            }
            

            return result;
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem itm in listView1.Items)
                if(itm.Selected)
                {
                    int cod = Convert.ToInt32(itm.SubItems[0].Text);

                    int index;

                    for(int i = 0; i < vector.Produse.Length; i++)
                        if(vector.Produse[i].Id_produs == cod)
                        {
                            index = i;
                            vector.Produse = stergeElement(vector.Produse, index);
                            break;
                        }

                }

            afisareProduse();

        }

        private void editeazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem itm in listView1.Items)
            {
                if(itm.Selected)
                {
                    AdaugaProdu frm = new AdaugaProdu();

                    int cod = Convert.ToInt32(itm.SubItems[0].Text);

                    Produs prodSelectat = null;

                    for(int i = 0; i < vector.Produse.Length; i++)
                        if(vector.Produse[i].Id_produs == cod)
                        {
                            prodSelectat = vector.Produse[i];
                            break;
                        }

                    frm.tbCod.Text = itm.SubItems[0].Text;
                    frm.tbDenumire.Text = itm.SubItems[1].Text;
                    frm.tbCantitate.Text = itm.SubItems[2].Text;
                    frm.tbPret.Text = itm.SubItems[3].Text;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {

                        try
                        {
                            int id = Convert.ToInt32(frm.tbCod.Text);
                            string denumire = frm.tbDenumire.Text;
                            int cantitate = Convert.ToInt32(frm.tbCantitate.Text);
                            float pret = (float)Convert.ToDouble(frm.tbPret.Text);

                            prodSelectat.Id_produs = id;
                            prodSelectat.Denumire = denumire;
                            prodSelectat.Cantitate = cantitate;
                            prodSelectat.Pret = pret;
                           
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            afisareProduse();
                        }

                    }
                }
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter sw = new StreamWriter("fisier.txt");

            for(int i = 0; i < vector.Produse.Length; i++)
                sw.WriteLine(vector.Produse[i].ToString());

            sw.Close();
        }

        private void pd_print(object sender, PrintPageEventArgs e)
        {
            Graphics gr = e.Graphics;

            string antet = "Cod               Denumire              Cantiate              Pret              Valoare";

            Font font = new Font(Font.FontFamily, 15);

            int antetLength = antet.Length;

            gr.DrawString("Cod               Denumire              Cantiate              Pret              Valoare", 
                font, new SolidBrush(Color.DarkBlue), e.PageBounds.X + 110, e.PageBounds.Y + 50);

            gr.DrawLine(new Pen(new SolidBrush(Color.DarkBlue)), e.PageBounds.X + 110, e.PageBounds.Y + 80, e.PageBounds.X + 665 + antetLength,
                e.PageBounds.Y + 80);

            int y = e.PageBounds.Y + 95;
            
            for(int i = 0; i < vector.Produse.Length; i++)
            {
                gr.DrawString(vector.Produse[i].Id_produs.ToString(), font, new SolidBrush(Color.DarkBlue), e.PageBounds.X + 120, e.PageBounds.Y + 95 + i * 30);
                gr.DrawString(vector.Produse[i].Denumire.ToString(), font, new SolidBrush(Color.DarkBlue), e.PageBounds.X + 245, e.PageBounds.Y + 95 + i * 30);
                gr.DrawString(vector.Produse[i].Cantitate.ToString(), font, new SolidBrush(Color.DarkBlue), e.PageBounds.X + 425, e.PageBounds.Y + 95 + i * 30);
                gr.DrawString(vector.Produse[i].Pret.ToString(), font, new SolidBrush(Color.DarkBlue), e.PageBounds.X + 560, e.PageBounds.Y + 95 + i * 30);
                gr.DrawString(vector.Produse[i].Valoare.ToString(), font, new SolidBrush(Color.DarkBlue), e.PageBounds.X + 680, e.PageBounds.Y + 95 + i * 30);


            }


        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_print);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();
        }

       
    }
}
