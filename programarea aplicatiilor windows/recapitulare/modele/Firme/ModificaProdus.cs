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
    public partial class ModificaProdus : Form
    {
        Produs p;
        public ModificaProdus(Produs p)
        {
            InitializeComponent();
            this.p = p;

            tbCod.Text = this.p.Cod.ToString();
            tbDenumire.Text = this.p.Denumire;
            tbPret.Text = this.p.Pret.ToString();
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

                    p.Cod = cod;
                    p.Denumire = denumire;
                    p.Pret = pret;

                    MessageBox.Show("Produs modificat cu succes!");
                    this.Close();

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
