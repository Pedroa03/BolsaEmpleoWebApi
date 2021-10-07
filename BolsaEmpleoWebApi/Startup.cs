using Capa_Datos.Repositorio;
using Capa_Entidad;
using Capa_Negocio;
using Capa_Negocio.Mapeo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleoWebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BolsaEmpleoWebApi", Version = "v1" });
            });

            services.AddAutoMapper(config =>
            {
                config.AddProfile<MapCategorias>();
                config.AddProfile<MapTipoUsuario>();
                
            });

            services.AddTransient<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddTransient<ICategoriaService, CategoriaService>();

            services.AddTransient<ITipoUsuarioRepositorio, TipoUsuarioRepositorio>();
            services.AddTransient<ITipoUsuarioService, TipoUsuarioService>();



            services.AddDbContext<BolsaEmpleoDBContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BolsaEmpleoWebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
