using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen_paw_prod
{
    public partial class FormAddEdit : Form
    {
        public Prod produsAdaugatEditat;
        public bool edit;
        public FormAddEdit()
        {
            InitializeComponent();
            this.Text = "Adaugare produs";
            produsAdaugatEditat = new Prod();
            edit = false;
        }
        public FormAddEdit(Prod p)
        {
            InitializeComponent();
            this.Text = "Editare produs";
            produsAdaugatEditat = new Prod(p.Cod, p.Denumire, p.Pret);
            edit = true;

            numCod.Value = p.Cod;
            txtDenumire.Text = p.Denumire;
            txtPret.Text = p.Pret.ToString("0.00");
            numCod.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int cod = (int)numCod.Value;
                string denumire = txtDenumire.Text.Trim();
                if (!float.TryParse(txtPret.Text, out float pret) || pret < 0)
                {
                    MessageBox.Show("Introduceti un pret valid (ex: 9.50)!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(denumire))
                    throw new Exception("Denumirea nu poate fi goala.");

                if (!edit && FakeDatabase.produse.Any(p => p.Cod == cod))
                    throw new Exception("Codul introdus exista deja.");

                produsAdaugatEditat.Cod = cod;
                produsAdaugatEditat.Denumire = denumire;
                produsAdaugatEditat.Pret = pret;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}", "Validare esuata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
