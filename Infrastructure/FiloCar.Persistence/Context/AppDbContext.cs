using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace FiloCar.Persistence.Context
{
    public class AppDbContext : DbContext
    {
      
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Station> Stations { get; set; } 
        public DbSet<Driver> Drives { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleAssigment> VehicleAssigments { get; set; }
        public DbSet<FuelLog> FuelLogs { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
    
}
