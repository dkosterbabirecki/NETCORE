using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interface;
using DataAccess.Implementation;
using DataAccess.Config;
using Entities;
using Services.Interface;
using Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Injector;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //Injector.Injector.Inject(services, Configuration);
            //services.AddScoped<IRepository<Person>, EFRepository<Person>>();

            services.AddDbContext<DbContext,EntityContext>(options => 
            options.UseLazyLoadingProxies(true).UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // aqui se inyecta siempre EFREpository cuando se usa un repository
            //services.AddDbContext<EntityContext>(options => options.UseSqlServer(""));
            services.AddScoped(typeof(IDataProvider<>), typeof(EFDataProvider<>));
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
