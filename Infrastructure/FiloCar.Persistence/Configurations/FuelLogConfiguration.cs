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
    public class FuelLogConfiguration : IEntityTypeConfiguration<FuelLog> // yakıt logu konfigürasyonu
    {
    

        public void Configure(EntityTypeBuilder<FuelLog> builder)
        {
            builder.HasKey(m => m.FuelLogId);
            Faker faker = new Faker("tr");

            FuelLog fuelLog = new()
            {
                FuelLogId = (23),
                VehicleId = (1), // mevcut bir araç ID’si kullanılmalı
                FuelDate = faker.Date.Recent(10), // son 10 gün içinden rastgele tarih
                Liter = faker.Random.Double(20, 80), // alınan yakıt miktarı (litre)
                LiterCount = faker.Random.Double(30, 40), // litre fiyatı
                StationId = (1), // istasyon adı
                CurrentKm = faker.Random.Int(1000, 100000) // yakıt alımındaki km
            };

            FuelLog fuelLog2 = new()
            {
                FuelLogId = (24),
                VehicleId = (2), // mevcut bir araç ID’si kullanılmalı
                FuelDate = faker.Date.Recent(10), // son 10 gün içinden rastgele tarih
                Liter = faker.Random.Double(20, 80), // alınan yakıt miktarı (litre)
                LiterCount = faker.Random.Double(30, 40), // litre fiyatı
                StationId= (2) ,// istasyon adı
                CurrentKm = faker.Random.Int(1000, 100000) // yakıt alımındaki km
            };
            FuelLog fuelLog3 = new()
            {
                FuelLogId = (25),
                VehicleId = (3), // mevcut bir araç ID’si kullanılmalı
                FuelDate = faker.Date.Recent(10), // son 10 gün içinden rastgele tarih
                Liter = faker.Random.Double(20, 80), // alınan yakıt miktarı (litre)
                LiterCount = faker.Random.Double(30, 40), // litre fiyatı
                StationId = (3), // istasyon adı
                CurrentKm = faker.Random.Int(1000, 100000) // yakıt alımındaki km
            };

            builder.HasData(fuelLog, fuelLog2, fuelLog3);

        }
    }
    
}
