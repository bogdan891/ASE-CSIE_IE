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
    public partial class CandidatForm : Form
    {
        List<Candidat> candidati;

        public CandidatForm(List<Candidat> candidati)
        {
            InitializeComponent();
            this.candidati = candidati;
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (tbCod.Text == "")
                errorProvider1.SetError(tbCod, "Introdu codul!");
            else if (tbNume.Text == "")
                errorProvider1.SetError(tbNume, "Introdu numele!");
            else if (tbMedie.Text == "")
                errorProvider1.SetError(tbMedie, "Introdu media!");
            else if (tbOptiuni.Text == "")
                errorProvider1.SetError(tbOptiuni, "Introdu macar o optiune!");
            else
            {
                try
                {
                    int cod = Convert.ToInt32(tbCod.Text);
                    string nume = tbNume.Text;
                    float medie = (float)Convert.ToDouble(tbMedie.Text);

                    string[] valori = tbOptiuni.Text.Split(',');

                    int[] optiuni = new int[valori.Length];

                    for(int i = 0; i < valori.Length; i++)
                    {
                        optiuni[i] = Convert.ToInt32(valori[i]);
                    }

                    candidati.Add(new Candidat(cod, nume, medie, optiuni));

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //errorProvider1.Clear();
                    //tbCod.Clear();
                    //tbNume.Clear();
                    //tbMedie.Clear();
                    //tbOptiuni.Clear();
                }
            }
        }
    }
}
