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
    public class MaintenanceRecordConfiguration : IEntityTypeConfiguration<MaintenanceRecord> // bakım kaydı konfigürasyonu
    {
        public void Configure(EntityTypeBuilder<MaintenanceRecord> builder)
        {
            builder.HasKey(m => m.Id);
            Faker faker = new Faker("tr");

            MaintenanceRecord maintenanceRecord1 = new MaintenanceRecord
            {
                Id = (41),
                VehicleId = (1), // örnek VehicleId
                MaintenanceDate = faker.Date.Past(10),
                Description = faker.Lorem.Sentence(),
                Cost = (double)faker.Finance.Amount(100, 1000),
                KmAtMaintenance = faker.Random.Int(10000, 300000), // örnek kilometre değeri
            };

            MaintenanceRecord maintenanceRecord2 = new MaintenanceRecord
            {
                Id = (42),
                VehicleId = (2), // örnek VehicleId
                MaintenanceDate = faker.Date.Past(10),
                Description = faker.Lorem.Sentence(),
                Cost = (double)faker.Finance.Amount(100, 1000),
                KmAtMaintenance = faker.Random.Int(10000, 300000), // örnek kilometre değeri
            };
            MaintenanceRecord maintenanceRecord3 = new MaintenanceRecord
            {
                Id = (43),
                VehicleId = (3), // örnek VehicleId
                MaintenanceDate = faker.Date.Past(10),
                Description = faker.Lorem.Sentence(),
                Cost = (double)faker.Finance.Amount(100, 1000),
                KmAtMaintenance = faker.Random.Int(10000, 300000), // örnek kilometre değeri
            };
            builder.HasData(maintenanceRecord1, maintenanceRecord2, maintenanceRecord3);
        }
    }


}

