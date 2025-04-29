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
    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            
            Faker faker = new Faker("tr");

            Station station1 = new()
            {
                StationId = 1,
                StationName = faker.Company.CompanyName(),
                StationAddress = faker.Address.FullAddress(),
                StationPhone = faker.Phone.PhoneNumber()
            };

            Station station2 = new()
            {
                StationId = 2,
                StationName = faker.Company.CompanyName(),
                StationAddress = faker.Address.FullAddress(),
                StationPhone = faker.Phone.PhoneNumber()
            };

            Station station3 = new()
            {
                StationId = 3,
                StationName = faker.Company.CompanyName(),
                StationAddress = faker.Address.FullAddress(),
                StationPhone = faker.Phone.PhoneNumber()
            };
            builder.HasData(station1, station2, station3);
        }
    }
}
