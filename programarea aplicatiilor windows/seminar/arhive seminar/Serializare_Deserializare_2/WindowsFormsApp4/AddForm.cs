using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var sectie = new Sectie();
            sectie.Nume = numeTextBox.Text;
            sectie.Candidat1 = (int)candidatNumeric1.Value;
            sectie.Candidat2 = (int)candidatNumeric2.Value;

            FakeDatabase.Sectii.Add(sectie);

            Close();
        }
    }
}
