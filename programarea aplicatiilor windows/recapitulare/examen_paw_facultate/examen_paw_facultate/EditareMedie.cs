using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen_paw_facultate
{
    public partial class EditareMedie : Form
    {
        private Student student;

        public EditareMedie(Student s)
        {
            InitializeComponent();
            student = s;

            textBox1.Text = s.NrMatricol.ToString();
            textBox2.Text = s.Nume;
            textBox3.Text = s.Medie.ToString("F2");

            this.btnSalvare.Click += new System.EventHandler(this.btnSalvare_Click);
        }

        public Student StudentModificat => student;

        private void btnSalvare_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox3.Text, out float nouaMedie))
            {
                if (nouaMedie >= 1.00f && nouaMedie <= 10.00f)
                {
                    student.Medie = nouaMedie;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Media trebuie să fie între 1.00 și 10.00");
                }
            }
            else
            {
                MessageBox.Show("Introduceți o medie validă (ex: 9.50)");
            }
        }
    }
}
