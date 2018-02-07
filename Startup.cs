using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CatalogoCursos.Dados;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace CatalogoCursos
{
    public class Startup
    {
        IConfiguration configuration { get; set; }
        public Startup(IConfiguration configuration){
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddDbContext<CatalogoContext>(options=>options.UseSqlServer(configuration.GetConnectionString("BancoCatalogoCursos")));
             services.AddMvc();
             services.AddSwaggerGen(c => {
                 c.SwaggerDoc("V1", new Info{
                    Version = "V1",
                    Title = "Cursos",
                    Description = "Doc",
                    TermsOfService = "none",
                    Contact = new Contact{
                        Name = "J",
                        Email = "",
                        Url = ""
                    }
                 });
                 var basePath = AppContext.BaseDirectory;
                 var xmlPath = Path.Combine(basePath, "CursosOnline.xml");
                 c.IncludeXmlComments(xmlPath);
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "API V1");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
