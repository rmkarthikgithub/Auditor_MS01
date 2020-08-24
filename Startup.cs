using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MC18_S1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MC18_S1
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
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });
            services.AddDbContext<Models.AuditorUserContext>(opts =>
            opts.UseSqlServer("AuditorUser"));
            services.AddTransient(typeof(IDataAccess<AuditorUser>), typeof(DataAccessRepository<AuditorUser>));
            services.AddTransient(typeof(IDataAccess<Portfolio>), typeof(DataAccessRepository<Portfolio>));
            services.AddTransient(typeof(IDataAccess<RequestAudit>), typeof(DataAccessRepository<RequestAudit>));
            services.AddMvc();
            

            services.AddDbContext<Models.AuditorUserContext>(opt =>
               opt.UseInMemoryDatabase("AuditorUser"));
            services.AddControllers();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Auditor Service");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    //endpoints.MapControllers();
            //    endpoints.MapControllerRoute("default", "{controller=Audit}/{action=GetAuditors}/{id?}");
              
            //});
        }
    }
}
