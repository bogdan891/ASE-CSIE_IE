using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen_paw_studenti
{
    public partial class AddEditForm : Form
    {
        public Student student;
        public AddEditForm(Student studentSelect)
        {
            InitializeComponent();
            this.Text = "Editeaza Media unui Student";
            txtMatricol.Text = studentSelect.Matricol.ToString();
            txtMatricol.ReadOnly = true;
            txtNume.Text = studentSelect.Nume;
            txtNume.ReadOnly = true;
            txtMedia.Text = studentSelect.Media.ToString();
            student = new Student(studentSelect.Matricol, studentSelect.Nume, studentSelect.Media);
            this.btnSalvare.Click += BtnSalvare_Click;
        }

        private void BtnSalvare_Click(object sender, EventArgs e)
        {
           if(float.TryParse(txtMedia.Text, out var nouaMedie))
           {
                if (nouaMedie >= 1.00f && nouaMedie <= 10.00f)
                {
                    student.Media = nouaMedie;
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
