using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen_paw_triunghi
{
    public partial class FormTriunghi : Form
    {
        private Color culoareSelectata = Color.Black;
        private static int codCurent = 1;
        public FormTriunghi()
        {
            InitializeComponent();
            textX1.Validating += ValidareTextNumeric;
            textY1.Validating += ValidareTextNumeric;
            textX2.Validating += ValidareTextNumeric;
            textY2.Validating += ValidareTextNumeric;
            textX3.Validating += ValidareTextNumeric;
            textY3.Validating += ValidareTextNumeric;
        }

        private void ValidareTextNumeric(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (!double.TryParse(txt.Text, out _))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt, "Introduceti un numar valid!");
            }
            else
            {
                errorProvider1.SetError(txt, "");
            }
        }
        private void btnAlegeCuloare_Click(object sender, EventArgs e)
        {
            if (colorTriunghi.ShowDialog() == DialogResult.OK)
            {
                culoareSelectata = colorTriunghi.Color;
                btnAlegeCuloare.BackColor = culoareSelectata;
            }
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            try
            {
                // Preluăm punctele
                Punct p1 = new Punct(double.Parse(textX1.Text), double.Parse(textY1.Text));
                Punct p2 = new Punct(double.Parse(textX2.Text), double.Parse(textY2.Text));
                Punct p3 = new Punct(double.Parse(textX3.Text), double.Parse(textY3.Text));

                string eticheta = textEticheta.Text;
                float grosime = (float)numGrosime.Value;

                Triunghi t = new Triunghi(p1, p2, p3, culoareSelectata, grosime, codCurent++, eticheta);

                FormPrincipal.ColectieTriunghiuri.Add(t);

                MessageBox.Show("Triunghi adăugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetFormular();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la adăugare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFormular()
        {
            textX1.Clear(); textY1.Clear();
            textX2.Clear(); textY2.Clear();
            textX3.Clear(); textY3.Clear();
            textEticheta.Clear();
            numGrosime.Value = 1;
            culoareSelectata = Color.Black;
            btnAlegeCuloare.BackColor = SystemColors.Control;
        }
    }
}
