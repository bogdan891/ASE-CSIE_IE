using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace model_credit
{
    public partial class AddEditCredit : Form
    {
        public Credit credit;
        bool edit;
        public AddEditCredit()
        {
            InitializeComponent();
            this.Text = "Adauga un nou client";
            edit = false;
            credit = new Credit();
        }
        public AddEditCredit(Credit c)
        {
            InitializeComponent();
            this.Text = "Editeaza dobanda unui client";
            credit = new Credit(c.Client, c.ValoareCredit, c.Dobanda, c.DataAcordarii, c.PerioadaCreditare);
            edit = true;

            txtClient.Text = credit.Client;
            txtValoare.Text = credit.ValoareCredit.ToString();
            txtDobanda.Text = credit.Dobanda.ToString();  
            dataAcord.Value = credit.DataAcordarii;
            numPerioada.Value = credit.PerioadaCreditare;
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                if (string.IsNullOrEmpty(txtClient.Text))
                {
                    erp.SetError(txtClient, "Introduceti un nume valid pentru client.");
                    return;
                }
                else
                {
                    credit.Client = txtClient.Text;
                }

                if(!double.TryParse(txtValoare.Text, out double valoareCredit))
                {
                    erp.SetError(txtValoare, "Introduceti un nr valid pt valoarea creditului.");
                    return;
                }
                else
                {
                    credit.ValoareCredit = valoareCredit;
                }

                if(!double.TryParse(txtDobanda.Text, out double dobanda))
                {
                    erp.SetError(txtValoare, "Introduceti un nr valid pt rata dobanzii.");
                    return;
                }
                else
                {
                    credit.Dobanda = dobanda;
                }

                credit.DataAcordarii = dataAcord.Value;
                credit.PerioadaCreditare = (int)numPerioada.Value;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                txtClient.ReadOnly = true;
                txtValoare.ReadOnly = true;
                dataAcord.Enabled = false;
                numPerioada.ReadOnly = true;
                if (!double.TryParse(txtDobanda.Text, out double dobanda))
                {
                    erp.SetError(txtValoare, "Introduceti un nr valid pt rata dobanzii.");
                    return;
                }
                else
                {
                    credit.Dobanda = dobanda;
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnAnulare_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
