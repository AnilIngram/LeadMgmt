using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadMgmt.Api.Infrastructure;
using LeadMgmt.Api.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LeadMgmt.Api
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
            services.AddDbContext<LeadMgmtContext>(opt => opt.UseSqlServer(Configuration["ConnectionString:DefaultConnection"]));
            services.AddMvc();
            // Register application services.
            services.AddScoped<ILeadsRepository, LeadsRepository>();
            services.AddSingleton(new MyDataContextFactory(Configuration));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                 builder =>
                 {
                     builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                 });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAllOrigins");
            app.UseMvc();
        }
    }
}
