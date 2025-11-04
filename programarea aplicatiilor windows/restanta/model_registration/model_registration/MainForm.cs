using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace model_registration
{
    public partial class MainForm : Form
    {
        public static List<AccessPackage> accessPackages = new List<AccessPackage>();
        public static BindingList<Registration> registrations = new BindingList<Registration>();
        public MainForm()
        {
            InitializeComponent();
            dgvReg.DataSource = registrations;
            UploadPackages();
            //Deserialiaze();
            this.Load += MainForm_Load;
            dgvReg.CellDoubleClick += dgvReg_CellDoubleClick;
            UpdateTotalCost();
        }
        public void MainForm_Load(object sender, EventArgs e)
        {
            dgvReg.ClearSelection();
            dgvReg.AutoGenerateColumns = false;
            dgvReg.Columns.Clear();

            dgvReg.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Company Name",
                DataPropertyName = "CompanyName",
                ReadOnly = true
            });

            dgvReg.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Number of Passes",
                DataPropertyName = "NbOfPasses",
                ReadOnly = true
            });

            dgvReg.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Access Package",
                DataPropertyName = "AccessPackageName",
                ReadOnly = true
            });
            dgvReg.Refresh();
        }

        public void UploadPackages()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text File|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach(var line in File.ReadLines(ofd.FileName))
                {
                    var part = line.Split(',');
                    int id = int.Parse(part[0]);
                    string name = part[1];
                    float price = float.Parse(part[2]);

                    accessPackages.Add(new AccessPackage(id, name, price));
                }
            }
        }

        public void Deserialiaze()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Binary Files|*.bin";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        registrations = (BindingList<Registration>)bf.Deserialize(fs);
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }

        private void addRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddRegForm();
            if(form.ShowDialog() == DialogResult.OK)
            {
                registrations.Add(form.reg);
                dgvReg.Refresh();
                UpdateTotalCost();
            }
        }

        public void dgvReg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Registration reg = (Registration)dgvReg.Rows[e.RowIndex].DataBoundItem;
            var edit = MessageBox.Show("Do you want to edit this registration?", "Edit a registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(edit == DialogResult.Yes)
            {
                var form = new AddRegForm(reg);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    reg.CompanyName = form.reg.CompanyName;
                    reg.NbOfPasses = form.reg.NbOfPasses;
                    reg.AccessPackageId = form.reg.AccessPackageId;
                    dgvReg.Refresh();
                    UpdateTotalCost();
                }
            }
            var delete = MessageBox.Show("Do you want to edit this registration?", "Edit a registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(delete == DialogResult.Yes)
            {
                registrations.Remove(reg);
                dgvReg.Refresh();
                UpdateTotalCost();
            }
        }

        private void serializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Binary file|*.bin";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, registrations);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotalCost()
        {
            double total = 0;
            foreach (var reg in registrations)
                total += (double)reg;

            statusStrip1.Text = $"Total cost: {total:0.00} RON";
        }
    }
}
