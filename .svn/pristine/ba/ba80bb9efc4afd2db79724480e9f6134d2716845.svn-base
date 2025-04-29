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
    public class VehicleAssigmentConfiguration : IEntityTypeConfiguration<VehicleAssigment> // araç atama 
    {


        public void Configure(EntityTypeBuilder<VehicleAssigment> builder)
        {
            builder.HasKey(m => m.VehicleAssigmentId);
            Faker faker = new Faker("tr");

            var start = faker.Date.Past(3); // Son 3 yıl içinde

            VehicleAssigment vehicleAssignment1 = new VehicleAssigment
            {
                VehicleAssigmentId = (50),
                VehicleId = (1), // örnek araç ID
                DriverId = (11),  // örnek sürücü ID
                AssignmentStart = start,
                AssignmentEnd = faker.Random.Bool()
                    ? faker.Date.Between(start, DateTime.Now)
                    : null, // bazıları hâlâ aktif olabilir
                Notes = faker.Lorem.Sentence()
            };

            VehicleAssigment vehicleAssigment2 = new VehicleAssigment
            {
                VehicleAssigmentId = (51),
                VehicleId = (2), // aynı araç ID'si
                DriverId = (22), // aynı sürücü ID'si
                AssignmentStart = start,
                AssignmentEnd = faker.Random.Bool()
                    ? faker.Date.Between(start, DateTime.Now)
                    : null, // bazıları hâlâ aktif olabilir
                Notes = faker.Lorem.Sentence()
            };

            VehicleAssigment vehicleAssigment3 = new VehicleAssigment
            {
                VehicleAssigmentId = (52),
                VehicleId =(3), // aynı araç ID'si
                DriverId = (22), // aynı sürücü ID'si
                AssignmentStart = start,
                AssignmentEnd = faker.Random.Bool()
                 ? faker.Date.Between(start, DateTime.Now)
                 : null, // bazıları hâlâ aktif olabilir
                Notes = faker.Lorem.Sentence()
            };

            builder.HasData(vehicleAssignment1, vehicleAssigment2, vehicleAssigment3);
        }
       
    }
   
}



