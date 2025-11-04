using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firme
{
    public partial class AdaugaProdus : Form
    {
        ContainerProduse produse;
        public AdaugaProdus(ContainerProduse produse)
        {
            InitializeComponent();
            this.produse = produse;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();


            if (tbCod.Text == "")
                errorProvider1.SetError(tbCod, "Introdu codul!");
            else if (tbDenumire.Text == "")
                errorProvider1.SetError(tbDenumire, "Introdu denumirea!");
            else if (tbPret.Text == "")
                errorProvider1.SetError(tbPret, "Introdu pretul!");
            else
            {
                try
                {
                    int cod = Convert.ToInt32(tbCod.Text);
                    string denumire = tbDenumire.Text;
                    float pret = (float)Convert.ToDouble(tbPret.Text);

                    Produs p = new Produs(cod, denumire, pret);

                    MessageBox.Show(p.ToString());

                    this.produse.Produse.Add(p);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    errorProvider1.Clear();
                    tbCod.Clear();
                    tbDenumire.Clear();
                    tbPret.Clear();
                }
            }

        }
    }
}
