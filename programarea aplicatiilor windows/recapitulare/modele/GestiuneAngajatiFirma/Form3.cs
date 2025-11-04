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
    public partial class Form3 : Form
    {
        Angajat a;
        public Form3(Angajat a)
        {
            InitializeComponent();
            this.a = a;

            textBox1.Text = a.Nume;
            dateTimePicker1.Value = a.DataNasterii;

            switch (a.IdCompanie)
            {
                case 0:
                    comboBox1.Text = "";
                    break;
                case 1:
                    comboBox1.Text = "1 - IBM SRL";
                    break;
                case 2:
                    comboBox1.Text = "2 - ORACLE SRL";
                    break;
                case 3:
                    comboBox1.Text = "3 - ENDAVA";
                    break;
            }

            
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

                    a.Nume = nume;
                    a.DataNasterii = dt;


                    if (comboBox1.Text == "")
                    {
                        a.IdCompanie = 0;
                    }
                    else
                    {
                        switch (comboBox1.Text)
                        {
                            case "1 - IBM SRL":
                                a.IdCompanie = 1;
                                break;

                            case "2 - ORACLE SRL":
                                a.IdCompanie = 2;
                                break;

                            case "3 - ENDAVA":
                                a.IdCompanie = 3;
                                break;
                        }
                    }




                }
                catch (Exception ex)
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
