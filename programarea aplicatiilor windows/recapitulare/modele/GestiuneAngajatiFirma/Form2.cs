using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestiuneAngajatiFirma
{
    public partial class Form2 : Form
    {
        List<Angajat> angajati;
        public Form2(List<Angajat> angajati)
        {
            InitializeComponent();
            this.angajati = angajati;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                errorProvider1.SetError(textBox1, "Introdu numele!");
            else if (textBox1.Text.Length < 2)
                errorProvider1.SetError(textBox1, "Numele trebuie sa contina minim 3 litere!");
            else if (DateTime.Now.Year - dateTimePicker1.Value.Year < 20)
                errorProvider1.SetError(dateTimePicker1, "Trebuie sa ai varsta mai mare sau egala cu 20 de ani!");
            else
            {
                try
                {
                    string nume = textBox1.Text;
                    DateTime dt = dateTimePicker1.Value;



                    if (comboBox1.Text == "")
                    {
                        angajati.Add(new Angajat(nume, dt));
                    } 
                    else
                    {
                        switch(comboBox1.Text)
                        {
                            case "1 - IBM SRL":
                                angajati.Add(new Angajat(nume, dt, 1));
                                break;

                            case "2 - ORACLE SRL":
                                angajati.Add(new Angajat(nume, dt, 2));
                                break;

                            case "3 - ENDAVA":
                                angajati.Add(new Angajat(nume, dt, 3));
                                break;
                        }
                    } 
                        

                   

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Close();
                }
            }

        }
    }
}
