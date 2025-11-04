using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subiect1
{
    public partial class AdaugaAngajatForm: Form
    {
        private AngajatRepository _angajatRepository = new AngajatRepository();
        public AdaugaAngajatForm()
        {
            InitializeComponent();

            var angajati = _angajatRepository.GetAngajati().OrderByDescending(x=>x.Nume).ToList();
            managerComboBox.DataSource = angajati;

            managerComboBox.DisplayMember = "Nume";//vad numele
            managerComboBox.ValueMember = "Cod";//se selecteaza codul

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var angajat = new Angajat();
            angajat.Nume = numeTextBox.Text;
            angajat.Salariu =(double) salariuUpDown.Value;
            angajat.CodManager =(int) managerComboBox.SelectedValue;

            _angajatRepository.Salveaza(angajat);
            Close();
        }
    }
}
