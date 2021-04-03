using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DataAccess.Interface;
using DataAccess.Implementation;
using Model;
using Services.Interface;
using Services.Sources;
using Microsoft.EntityFrameworkCore;

namespace Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // add scoped significa que cada clase que use IRepository va a inyectar EFRepository
            services.AddScoped<IRepository<Person>, EFRepository<Person>>();

            services.AddDbContext<DbContext,EntityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // aqui se inyecta siempre EFREpository cuando se usa un repository
            //services.AddDbContext<EntityContext>(options => options.UseSqlServer(""));
            services.AddScoped(typeof(IDataProvider<>), typeof(EFDataProvider<>));
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
