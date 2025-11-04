using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReferinteBibliografice
{
    public partial class AdaugaManual : Form
    {
        List<Carte> publicatii;
        public AdaugaManual(List<Carte> publicatii)
        {
            InitializeComponent();
            this.publicatii = publicatii;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();


            if (tbISBN.Text == "")
            {
                errorProvider1.SetError(tbISBN, "Introdu ISBN-ul!");
                MessageBox.Show("Introdu ISBN-ul!");
            } 
            else if (cbCategorie.Text == "")
            {
                errorProvider1.SetError(cbCategorie, "Selecteaza categoria!");
                MessageBox.Show("Selecteaza categoria!");

            }
            else if (tbTitlu.Text == "")
            {
                errorProvider1.SetError(tbTitlu, "Introdu titlul!");
                MessageBox.Show("Introdu titlul!");

            }
            else if (tbPret.Text == "")
            {
                errorProvider1.SetError(tbPret, "Introdu pretul!");
                MessageBox.Show("Introdu pretul!");

            }
            else
            {
                try
                {
                    string isbn = tbISBN.Text;
                    string categorie = cbCategorie.Text;
                    string titlu = tbTitlu.Text;
                    float pret = (float)Convert.ToDouble(tbPret.Text);

                    Carte c = new Carte(isbn, categorie, titlu, pret);

                    MessageBox.Show(c.ToString());

                    this.publicatii.Add(c);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    errorProvider1.Clear();
                    tbISBN.Clear();
                    cbCategorie.Text = "";
                    tbTitlu.Clear();
                    tbPret.Clear();
                }
            }
        }
    }
}
