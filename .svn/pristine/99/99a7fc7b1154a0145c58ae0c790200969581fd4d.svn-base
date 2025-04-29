using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;
using FiloCar.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiloCar.Persistence.Configurations
{
    public class DepartmanConfiguration : IEntityTypeConfiguration<Departman> // departman konfigürasyonu
    {
        public void Configure(EntityTypeBuilder<Departman> builder)
        {
            builder.HasKey(m => m.DepartmanId);

            Faker faker = new Faker("tr");

            var departman1 = new Departman
            {
                DepartmanId = (1111),
                Name = faker.Commerce.Department(),
                City = faker.Address.City(),
                District = faker.Address.County()
            };

            var departman2 = new Departman
            {
                DepartmanId = (2222),
                Name = faker.Commerce.Department(),
                City = faker.Address.City(),
                District = faker.Address.County()
            };

            var departman3 = new Departman
            {
                DepartmanId = (3333),
                Name = faker.Commerce.Department(),
                City = faker.Address.City(),
                District = faker.Address.County()
            };

            builder.HasData(departman1,departman2, departman3);


        }
    }
}
