using System;
using System.Collections.Generic;
using System.Linq;
using FiloCar.Application.Interface.Repositories;
using FiloCar.Application.Interface.UnitOfWorks;
using FiloCar.Persistence.Context;
using FiloCar.Persistence.Repository;
using FiloCar.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FiloCar.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SQLServer");
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(connectionString)); // Burada bağlantı dizesi doğru olmalı

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
        }
    }
}

