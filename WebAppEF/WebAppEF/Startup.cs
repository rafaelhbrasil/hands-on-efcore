using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppEF.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebAppEF
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
            // adicione as linhas abaixo dentro da função que já existe
            var connection = Configuration.GetConnectionString(nameof(WebAppDbContext));
            services.AddDbContext<WebAppDbContext>(options => options.UseMySql(connection));
            services.AddScoped<DbContext, WebAppDbContext>();

            // manter a linha abaixo
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        //public class ContextFactory : IDesignTimeDbContextFactory<WebAppDbContext>
        //{
        //    const string _connectionString = "Server=localhost; Database=webapp-ef; Uid=root; DefaultCommandTimeout=60; Allow User Variables=true";

        //    WebAppDbContext IDesignTimeDbContextFactory<WebAppDbContext>.CreateDbContext(string[] args)
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder<WebAppDbContext>();
        //        optionsBuilder.UseMySql(_connectionString);
        //        return new WebAppDbContext(optionsBuilder.Options);
        //    }
        //}
    }
}
