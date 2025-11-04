using CarRentalApp.Entities;
using CarRentalApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarRentalApp.Services
{
    public class CarService
    {
        private CarRepository _carRepository;
        private const string licenseNumberRegex = "^[A-Z]{1,2}[0-9]{2,3}[A-Z]{3}$";

        public CarService() {
            _carRepository = new CarRepository();
        }

        public void AddCar(Car car) {
            //facem validari
            if (_carRepository.ExistsByLicenseNumber(car.LicenseNumber) == true) {
                //masina exista, nu salvez si dau eroare
                throw new Exception($"Masina cu numarul de inmatriculare {car.LicenseNumber} deja exista");
            }

            if(!Regex.IsMatch(car.LicenseNumber.ToUpper(), licenseNumberRegex)) {
                throw new Exception($"Numarul de inmatriculare {car.LicenseNumber} nu este valid");
            }

            _carRepository.Add(car);
        }
    }
}
