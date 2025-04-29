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
    public class DriverConfiguration : IEntityTypeConfiguration<Driver> // sürücü konfigürasyonu
    {
     
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(m => m.DriverId);
            var faker = new Faker("tr");

            var driver1 = new Driver
            {
                DriverId = (11),
                DepartmanId = (1111),
                FullName = faker.Name.FullName(), // FullName alanı için Faker kullanımı
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                PhoneNumber = faker.Phone.PhoneNumber(),
                IsActive = true,
                LicenseNumber = faker.Random.AlphaNumeric(10)
            };
            var driver2 = new Driver
            {
                DriverId = (22),
                DepartmanId =(2222), // aynı departmana bağlı olabilir
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                FullName = faker.Name.FullName(),
                PhoneNumber = faker.Phone.PhoneNumber(),
                IsActive = false,
                LicenseNumber = faker.Random.AlphaNumeric(10)
            };

            builder.HasData(driver1, driver2);
        }
    }
    
}
