using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditareImagini
{
    public partial class AdaugaPoligon : Form
    {
        List<Poligon> poligoane;
        public AdaugaPoligon(List<Poligon> poligoane)
        {
            InitializeComponent();
            this.poligoane = poligoane;
        }

        private bool punctNegativ()
        {
            string[] puncte = tbPuncte.Text.Split(',');

            for (int i = 0; i < puncte.Length; i++)
            {
                string[] coordonate = puncte[i].Split(';');

                int x = Convert.ToInt32(coordonate[0]);
                int y = Convert.ToInt32(coordonate[1]);

                if (x < 0 || y < 0)
                {
                    return true;
                }
            }

            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            bool ok = true;

            if (tbCuloare.Text == "")
                errorProvider1.SetError(tbCuloare, "Introdu culoare!");
            else if (tbGrosime.Text == "")
                errorProvider1.SetError(tbGrosime, "Introdu grosimea!");
            else if (tbCod.Text == "")
                errorProvider1.SetError(tbCod, "Introdu codul figurii!");
            else if (tbEticheta.Text == "")
                errorProvider1.SetError(tbEticheta, "Introdu eticheta!");
            else if (tbPuncte.Text == "")
                errorProvider1.SetError(tbPuncte, "Introdu punctele!");
            else if (punctNegativ())
                errorProvider1.SetError(tbPuncte, "Ai introdus un punct negativ! [NU SE POATE]!");
            else
            {
                try
                {
                    string culoare = tbCuloare.Text;
                    int grosime = Convert.ToInt32(tbGrosime.Text);
                    int cod_figura = Convert.ToInt32(tbCod.Text);
                    string eticheta = tbEticheta.Text;

                    string[] puncte = tbPuncte.Text.Split(',');

                    List<Punct> pcts = new List<Punct>();

                    for(int i = 0; i < puncte.Length; i++)
                    {
                        string[] coordonate = puncte[i].Split(';');

                        int x = Convert.ToInt32(coordonate[0]);
                        int y = Convert.ToInt32(coordonate[1]);

                        if (x < 0 || y < 0)
                        {
                            errorProvider1.SetError(tbPuncte, "Ai introdus un punct NEGATIV! Nu se poate!");
                            ok = false;
                            break;

                        }

                        pcts.Add(new Punct(x, y));

                    }

                    if(ok)
                    {
                        Poligon pol = new Poligon(pcts, culoare, grosime, cod_figura, eticheta);

                        MessageBox.Show("Poligon salvat cu succes!");

                        this.poligoane.Add(pol);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    errorProvider1.Clear();
                    tbCuloare.Clear();
                    tbGrosime.Clear();
                    tbCod.Clear();
                    tbEticheta.Clear();
                    tbPuncte.Clear();
                }
            }
        }
    }
}
