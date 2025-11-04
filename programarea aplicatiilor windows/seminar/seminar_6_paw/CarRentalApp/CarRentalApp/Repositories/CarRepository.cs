using CarRentalApp.Database;
using CarRentalApp.Entities;
using System.Linq;

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
    }
}
