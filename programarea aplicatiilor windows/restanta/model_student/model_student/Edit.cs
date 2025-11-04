using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace model_student
{
    public partial class Edit : Form
    {
        private Student stud;
        public Edit(Student s)
        {
            InitializeComponent();
            stud = s;
            txtNume.Text = stud.Nume;
            txtNrMatricol.Text = stud.NrMatricol.ToString();
            txtMedia.Text = stud.Medie.ToString("F2");

            this.btnSalvare.Click += btnSalvare_Click;
            this.bntAnulare.Click += bntAnulare_Click;
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
            if(float.TryParse(txtMedia.Text, out float mediaNoua))
            {
                if (mediaNoua >= 1.00f && mediaNoua <= 10.00f)
                {
                    stud.Medie = mediaNoua;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    errorProvider.SetError(txtMedia, "Media trebuie sa fie intre 1.00 si 10.00.");
                }
            }
            else
            {
                errorProvider.SetError(txtMedia, "Introduceti o valoare NUMERICA VALIDA pentru media studentului!");
            }
        }

        private void bntAnulare_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
