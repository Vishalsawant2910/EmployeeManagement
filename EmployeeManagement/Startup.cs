using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config  = config;   
        }

         
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseMySql(_config.GetConnectionString("EmployeeDbConnection")));
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

                        app.UseStaticFiles();
                       app.UseMvcWithDefaultRoute();


            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!!");

            //});

            //{
            //    DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
            //    developerExceptionPageOptions.SourceCodeLineCount= 1;
            //    app.UseDeveloperExceptionPage( developerExceptionPageOptions);
            //}


             

          


            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("home.html");
            //app.UseFileServer(fileServerOptions);

            // app.UseFileServer( );


            //DefaultFilesOptions defaultfileoptions= new DefaultFilesOptions();
            //defaultfileoptions.DefaultFileNames.Clear();
            //defaultfileoptions.DefaultFileNames.Add("home.html");
            //app.UseDefaultFiles(defaultfileoptions);






        }
    }
}
