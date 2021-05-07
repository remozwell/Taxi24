using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24RestAPI.Data;
using Microsoft.EntityFrameworkCore;
using Taxi24RestAPI.Bussiness;

namespace Taxi24RestAPI
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

            services.AddSingleton(GetConfiguration());
            services.AddSingleton(GetPriceGenerator());


            bool.TryParse(Configuration["UseSQLite"], out bool useSQLite);
            if (useSQLite)
            {
                services.AddEntityFrameworkSqlite().AddDbContext<TaxiContext>(options => options.UseSqlite($"Filename={Configuration["SQLiteFile"]}"));

            }
            else
            {
            services.AddDbContext<TaxiContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TaxiDBConnection")));

            }



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        protected ConfigurationContext GetConfiguration()
        {
            double.TryParse(Configuration["KMDefaultRadius"], out double kmDefault);
            int.TryParse(Configuration["ConductoresDisponiblesDefault"], out int ConductoresDisponiblesDefault);
            
            return new ConfigurationContext(kmDefault, ConductoresDisponiblesDefault);
        }



        protected PriceGenerator GetPriceGenerator()
        {
            double.TryParse(Configuration["CostoBase"], out double CostoBase);
            double.TryParse(Configuration["CostoKilometro"], out double CostoKilometro);
            double.TryParse(Configuration["CostoMinuto"], out double CostoMinuto);
            return new PriceGenerator(CostoBase, CostoKilometro, CostoMinuto);
        }
    }
}
