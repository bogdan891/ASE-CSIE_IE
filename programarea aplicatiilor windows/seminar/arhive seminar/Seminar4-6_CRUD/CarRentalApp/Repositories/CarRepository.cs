using CarRentalApp.Database;
using CarRentalApp.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp.Repositories
{
    public class CarRepository
    {
        public bool ExistsByLicenseNumber(string licenseNumber) {
            return FakeDatabase.Cars.FirstOrDefault(car => car.LicenseNumber == licenseNumber) != null;            
        }

        public void Add(Car car) {
            FakeDatabase.Cars.Add(car);
        }

        public void Update(Car car) {
            var existingCar = FakeDatabase.Cars.FirstOrDefault(x => x.Id == car.Id);
            existingCar.Make = car.Make;
            existingCar.Model = car.Model;
            existingCar.Year = car.Year;
            existingCar.Seats = car.Seats;
            existingCar.LicenseNumber = car.LicenseNumber;
            existingCar.HasInsurance = car.HasInsurance;
        }

        public void Delete(Car car) {
            FakeDatabase.Cars.Remove(car);
        }
    }
}
