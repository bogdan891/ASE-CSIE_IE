using CarRentalApp.Entities;
using System;
using System.Collections.Generic;

namespace CarRentalApp.Database
{
    public static class FakeDatabase
    {
        public static List<Car> Cars = new List<Car>()
        {
            new Car()
            {
                Id = Guid.NewGuid(),
                Make = "Skoda",
                Model = "Octavia",
                Year = 2003,
                Seats = 5,
                HasInsurance = false,
                LicenseNumber = "B123ABC"
            },
            new Car()
            {
                Id = Guid.NewGuid(),
                Make = "Fiat",
                Model = "Multipla",
                Year = 2000,
                Seats = 6,
                HasInsurance = true,
                LicenseNumber = "VN23XYZ"
            }
        };
    }
}
