using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Interface;
using DataAccess.Implementation;
using DataAccess.Config;
using Services.Interface;
using Services.Implementation;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Injector
{
    public static class Injector
    {

        public static void Inject(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository<Person>, EFRepository<Person>>();

            services.AddDbContext<DbContext, EntityContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            // aqui se inyecta siempre EFREpository cuando se usa un repository
            //services.AddDbContext<EntityContext>(options => options.UseSqlServer(""));
            services.AddScoped(typeof(IDataProvider<>), typeof(EFDataProvider<>));
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
        }

    }
}
