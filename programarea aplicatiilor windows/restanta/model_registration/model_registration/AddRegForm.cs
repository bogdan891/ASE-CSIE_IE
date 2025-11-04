using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace model_registration
{
    public partial class AddRegForm : Form
    {
        public Registration reg;
        public AddRegForm()
        {
            InitializeComponent();
            reg = new Registration();
            this.Text = "Add a registration";
            comboPackage.DataSource = MainForm.accessPackages;
            comboPackage.DisplayMember = "Name";
            comboPackage.ValueMember = "Id";
            comboPackage.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public AddRegForm(Registration r)
        {
            InitializeComponent();
            reg = new Registration(r.CompanyName, r.NbOfPasses, r.AccessPackageId);
            this.Text = "Edit a registration";
            comboPackage.DataSource = MainForm.accessPackages;
            comboPackage.DisplayMember = "Name";
            comboPackage.ValueMember = "Id";
            comboPackage.DropDownStyle = ComboBoxStyle.DropDownList;

            txtName.Text = reg.CompanyName;
            numPasses.Value = reg.NbOfPasses;
            comboPackage.SelectedValue = reg.AccessPackageId;
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                if(string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please introduce a company name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if(MainForm.registrations.Any(x => x.CompanyName == name))
                {
                    MessageBox.Show("This name is already used!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                int nb = (int)numPasses.Value;
                int package = (int)comboPackage.SelectedValue;
                if(comboPackage.SelectedValue == null)
                {
                    MessageBox.Show("Please select an access package!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                reg.CompanyName = name;
                reg.NbOfPasses = nb;
                reg.AccessPackageId = package;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnulare_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
