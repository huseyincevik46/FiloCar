using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using FiloCar.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiloCar.Persistence.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle> // araç konfigürasyonu
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(m => m.VehicleId);
            Faker faker = new Faker("tr");

            Vehicle vehicle1 = new()
            {
                VehicleId = (1),
                PlateNumber = ("46ABO463"),
                Km = faker.Random.Int(0, 200000),
                DepartmanId = (2222), // örnek DepartmanId
                Model = faker.Vehicle.Model(),
                Brand = faker.Vehicle.Manufacturer(),
                Year = faker.Date.Past(10).Year,
                IsActive = faker.Random.Bool(),
                AddTime = faker.Date.Past(10),
                FuelType = faker.PickRandom(new[] { "Benzin", "Dizel", "LPG" }) // rastgele yakıt türü
            };

            Vehicle vehicle2 = new()
            {
                VehicleId = (2),
                PlateNumber = ("46ABC463"),
                Km = faker.Random.Int(0, 200000),
                DepartmanId = null, // örnek DepartmanId
                Model = faker.Vehicle.Model(),
                Brand = faker.Vehicle.Manufacturer(),
                Year = faker.Date.Past(10).Year,
                IsActive = faker.Random.Bool(),
                AddTime = faker.Date.Past(10),
                FuelType = faker.PickRandom(new[] { "Benzin", "Dizel", "LPG" }) // rastgele yakıt türü
            };

            Vehicle vehicle3 = new()
            {
                VehicleId = (3),
                PlateNumber = ("46ABD463"),
                Km = faker.Random.Int(0, 200000),
                DepartmanId = null, // örnek DepartmanId
                Model = faker.Vehicle.Model(),
                Brand = faker.Vehicle.Manufacturer(),
                Year = faker.Date.Past(10).Year,
                IsActive = faker.Random.Bool(),
                AddTime = faker.Date.Past(10),
                FuelType = faker.PickRandom(new[] { "Benzin", "Dizel", "LPG" }) // rastgele yakıt türü
            };

            builder.HasData(vehicle1, vehicle2,vehicle3);
        }
    }
}
