using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComenziPizza
{
    public partial class Form2 : Form
    {
        List<ComandaPizza> comenzi;
        public Form2(List<ComandaPizza> comenzi)
        {
            InitializeComponent();
            this.comenzi = comenzi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (tbNume.Text == "")
                errorProvider1.SetError(tbNume, "Introdu numele!");
            else if (comboBox1.Text == "")
                errorProvider1.SetError(comboBox1, "Alege blatul!");
            else if (tbDurata.Text == "")
                errorProvider1.SetError(tbDurata, "Introdu durata!");
            else
            {
                try
                {
                    string nume = tbNume.Text;
                    string blat = comboBox1.Text;
                    int durata = Convert.ToInt32(tbDurata.Text);

                    ComandaPizza com = new ComandaPizza(nume, blat, durata, new List<Topping>());

                    comenzi.Add(com);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    tbDurata.Clear();
                    comboBox1.Text = "";
                    tbNume.Clear();
                    errorProvider1.Clear();
                }
            }
        }
    }
}
