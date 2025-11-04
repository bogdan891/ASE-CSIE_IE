using CarRentalApp.Entities;
using CarRentalApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class AddCarForm: Form
    {
        private CarService _carService;

        public AddCarForm()
        {
            InitializeComponent();
            _carService = new CarService();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e) {
            var car = new Car();
            car.Id = Guid.NewGuid();
            car.Make = makeTextBox.Text;
            car.Model = modelTextBox.Text;
            car.Year = Convert.ToInt32(yearNumericUpDown.Value);
            car.Seats = Convert.ToInt32(seatsNumericUpDown.Value);
            car.LicenseNumber = licenseNumberTextBox.Text;
            car.HasInsurance = hasInsuranceCheckBox.Checked;
            try {
                _carService.AddCar(car);
                Close();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
