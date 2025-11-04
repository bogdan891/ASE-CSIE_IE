using System;
using System.Linq;
using System.Windows.Forms;

namespace examen_paw_angajati
{
    public partial class FormAddEdit : Form
    {
        public Angajat angajatAdaugatEditat;
        private Angajat referintaAngajatOriginal;
        private bool edit;
        private bool ok = true;

        public FormAddEdit()
        {
            InitializeComponent();
            this.Text = "Adaugă un angajat";
            edit = false;

            comboCompanie.DataSource = FakeDatabase.companii;
            comboCompanie.DisplayMember = "Nume";
            comboCompanie.ValueMember = "Id";

            angajatAdaugatEditat = new Angajat(); // gol pentru adăugare
        }

        public FormAddEdit(Angajat angajat)
        {
            InitializeComponent();
            this.Text = "Editează un angajat";
            edit = true;

            referintaAngajatOriginal = angajat;

            txtNume.Text = angajat.Nume;
            dateDN.Value = angajat.DataNasterii;

            comboCompanie.DataSource = FakeDatabase.companii;
            comboCompanie.DisplayMember = "Nume";
            comboCompanie.ValueMember = "Id";
            comboCompanie.SelectedItem = FakeDatabase.companii.FirstOrDefault(c => c.Id == angajat.IDCompanie);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                ok = true;

                // Validare nume
                string nume = txtNume.Text;
                if (string.IsNullOrWhiteSpace(nume))
                {
                    errorProvider1.SetError(txtNume, "Introduceți un nume valid!");
                    ok = false;
                }

                // Validare vârstă minim 20 ani
                DateTime dataNasterii = dateDN.Value;
                int varsta = DateTime.Now.Year - dataNasterii.Year;
                if (dataNasterii > DateTime.Now.AddYears(-varsta)) varsta--;
                if (varsta < 20)
                {
                    errorProvider1.SetError(dateDN, "Angajatul trebuie să aibă cel puțin 20 de ani.");
                    ok = false;
                }

                // Validare companie
                if (comboCompanie.SelectedItem == null)
                {
                    errorProvider1.SetError(comboCompanie, "Selectați o companie.");
                    ok = false;
                }

                if (!ok) return;

                // Salvare în funcție de mod
                if (edit)
                {
                    referintaAngajatOriginal.Nume = nume;
                    referintaAngajatOriginal.DataNasterii = dataNasterii;
                    referintaAngajatOriginal.IDCompanie = ((Companie)comboCompanie.SelectedItem).Id;
                }
                else
                {
                    angajatAdaugatEditat = new Angajat(
                        nume,
                        dataNasterii,
                        ((Companie)comboCompanie.SelectedItem).Id
                    );
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
