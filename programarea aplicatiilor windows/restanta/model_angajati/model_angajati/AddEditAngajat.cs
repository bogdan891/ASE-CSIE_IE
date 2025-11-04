using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace model_angajati
{
    public partial class AddEditAngajat : Form
    {
        public Angajat angajat;
        public AddEditAngajat()
        {
            InitializeComponent();
            angajat = new Angajat();
            this.Text = "Adauga un angajat";

            comboCompanie.DataSource = MainForm.companii;
            comboCompanie.DisplayMember = "Nume";
            comboCompanie.ValueMember = "Id";
            comboCompanie.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public AddEditAngajat(Angajat ang)
        {
            InitializeComponent();
            angajat = new Angajat(ang.Nume, ang.DataNasterii,ang.IdCompanie);
            this.Text = "Editeaza un angajat";

            comboCompanie.DataSource = MainForm.companii;
            comboCompanie.DisplayMember = "Nume";
            comboCompanie.ValueMember = "Id";
            comboCompanie.DropDownStyle = ComboBoxStyle.DropDownList;

            txtNume.Text = ang.Nume;
            dataN.Value = ang.DataNasterii;
            comboCompanie.SelectedValue = ang.IdCompanie;   
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
            try
            {
                err.Clear();
                if(txtNume.Text.Length < 2)
                {
                    err.SetError(txtNume, "Numele trebuie sa contina cel putin 2 caractere!");
                    MessageBox.Show("Numele trebuie sa contina cel putin 2 caractere!", "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int varsta = DateTime.Now.Year - dataN.Value.Year;
                if (dataN.Value > DateTime.Now.AddYears(-varsta)) varsta--;
                if (varsta < 20)
                {
                    err.SetError(dataN, "Angajatul trebuie sa aiba impliniti cel putin 20 de ani!");
                    MessageBox.Show("Angajatul trebuie sa aiba impliniti cel putin 20 de ani!", "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(comboCompanie.SelectedItem == null)
                {
                    err.SetError(comboCompanie, "Selecteaza o companie!");
                    MessageBox.Show("Selecteaza o companie!", "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                angajat.Nume = txtNume.Text;
                angajat.DataNasterii = dataN.Value;
                angajat.IdCompanie = (int)comboCompanie.SelectedValue;

                this.DialogResult = DialogResult.OK;
                this.Close();
            } 
            catch(Exception ex)
            {
                MessageBox.Show("Eroare neașteptata: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnulare_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
