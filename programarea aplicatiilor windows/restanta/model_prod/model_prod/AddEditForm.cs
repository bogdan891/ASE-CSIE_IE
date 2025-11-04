using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace model_prod
{
    public partial class AddEditForm : Form
    {
        public Prod produs;
        public bool edit;
        public AddEditForm()
        {
            InitializeComponent();
            this.Text = "Adauga un produs";
            produs = new Prod();
            edit = false;

            numCod.ReadOnly = false;
            txtDenumire.ReadOnly = false;
            txtPret.ReadOnly = false;
        }

        public AddEditForm(Prod p)
        {
            InitializeComponent();
            this.Text = "Editeaza un produs";
            produs = new Prod(p.Cod, p.Denumire, p.Pret);
            edit = true;
            numCod.ReadOnly = true;
            txtDenumire.ReadOnly = true;
            txtPret.ReadOnly = false;

            numCod.Value = p.Cod;
            txtDenumire.Text = p.Denumire;
            txtPret.Text = p.Pret.ToString();
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
            err.Clear();
            try
            {
                if(!edit)
                {
                    int cod = (int)numCod.Value;
                    if(FakeDatabase.produse.Any(x => x.Cod == cod))
                    {
                        err.SetError(numCod, "Codul introdus exista deja!");
                        return;
                    }
                    string denumire = txtDenumire.Text;
                    if(string.IsNullOrEmpty(denumire))
                    {
                        err.SetError(txtDenumire, "Campul cu denumire nu poate fi necompletat!");
                        return;
                    }
                    produs.Cod = cod;
                    produs.Denumire = denumire;
                }
                if(!double.TryParse(txtPret.Text, out double pret))
                {
                    err.SetError(txtPret, "Introduceti un pret valid!");
                    return;
                }
                produs.Pret = pret;
                this.DialogResult = DialogResult.OK;
                this.Close();
            } catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}", "Validare esuata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAnulare_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
