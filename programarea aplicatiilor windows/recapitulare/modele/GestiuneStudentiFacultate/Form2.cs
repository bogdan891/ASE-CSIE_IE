using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestiuneStudentiFacultate
{
    
    public partial class Form2 : Form
    {
        Student stud;
        public Form2(Student stud)
        {
            InitializeComponent();
            this.stud = stud;

            textBox1.Text = stud.NrMatricol.ToString();
            textBox2.Text = stud.Nume;
            tbMedie.Text = stud.Medie.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tbMedie.Text != "")
            {
                try
                {
                    float medie = (float)Convert.ToDouble(tbMedie.Text);

                    stud.Medie = medie;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    MessageBox.Show("Media a fost modificata!");
                    this.Close();
                }
            }

        }
    }
}
