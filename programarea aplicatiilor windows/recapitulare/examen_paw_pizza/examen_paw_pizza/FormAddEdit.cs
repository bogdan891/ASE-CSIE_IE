using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen_paw_pizza
{
    public partial class FormAddEdit : Form
    {
        bool editat = false;
        public Models.ComandaPizza comanda;

        public FormAddEdit()
        {
            InitializeComponent();
            this.Text = "Adauga o comanda!";
            editat = false;
            foreach (var top in Utils.FakeDatabase.topping)
            {
                ckTopping.Items.Add(top);
            }
            comanda = new Models.ComandaPizza();
        }

        public FormAddEdit(Models.ComandaPizza c)
        {
            InitializeComponent();
            this.Text = "Editeaza o comanda!";
            editat = true;
            comanda = (Models.ComandaPizza)c.Clone();
            txtNume.Text = c.Nume;
            txtBlat.Text = c.Blat;
            numDurata.Value = c.DurataRealizare;
            foreach (var top in Utils.FakeDatabase.topping)
            {
                int index = ckTopping.Items.Add(top);

                if (c.Topping.Any(t => t.Cod == top.Cod))
                {
                    ckTopping.SetItemChecked(index, true);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string nume = txtNume.Text;
                if(string.IsNullOrWhiteSpace(nume))
                {
                    errorProvider1.SetError(txtNume, "Numele nu poate fi gol!");
                }
                string blat = txtBlat.Text;
                if(string.IsNullOrWhiteSpace(blat))
                {
                    errorProvider1.SetError(txtBlat, "Blatul nu poate fi gol!");
                }
                int durata = (int)numDurata.Value;
                List<Models.Topping> topping = new List<Models.Topping>();
                foreach(var item in ckTopping.CheckedItems)
                {
                    if (item is Models.Topping top)
                    {
                        topping.Add(top);
                    }
                }
                comanda = new Models.ComandaPizza(nume, blat, durata, topping);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
