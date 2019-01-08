using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApiSSESI.Models;

namespace WebApiSSESI
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
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)                
            //    .AddJwtBearer(options =>
                 //options.TokenValidationParameters = new TokenValidationParameters
                 //{
                 //    ValidateIssuer = true,
                 //    ValidateAudience = true,
                 //    ValidateLifetime = true,
                 //    ValidateIssuerSigningKey = true,
                 //    ValidIssuer = "tudominio.com", //esto debe ir en un archivo de configuracion
                 //    ValidAudience = "tudominio.com", //esto debe ir en un archivo de configuracion
                 //    IssuerSigningKey = new SymmetricSecurityKey(
                 //   Encoding.UTF8.GetBytes(Configuration["Llave_super_secreta"])),
                 //    ClockSkew = TimeSpan.Zero
                 //});

            /*trabajar en memoria*/ 
            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseInMemoryDatabase("SSESIDB"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(ConfigureJson);
        }

        private void ConfigureJson(MvcJsonOptions obj)
        {
            obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();

            if (!context.CentrosEducativos.Any())
            {
                context.CentrosEducativos.AddRange(new List<CentroEducativo>()
                {
                    new CentroEducativo(){ Nombre = "Prado", Direccion = "Sta. Lucia 4420", Barrio = "Belveder", Telefonos = new List<TelefonoCEducativo>()
                    {
                        new TelefonoCEducativo() { Telefono = "123456"}
                    } },
                    new CentroEducativo(){ Nombre ="Colegio", Direccion = "Sta. Lucia 4420", Barrio = "Belveder", Telefonos = new List<TelefonoCEducativo>()
                    {
                        new TelefonoCEducativo(){ Telefono = "654321"}, new TelefonoCEducativo(){Telefono = "0999999" }
                    } },
                    new CentroEducativo(){ Nombre ="Marista", Direccion = "Sta. Lucia 4420", Barrio = "Belveder"}
                });

                context.SaveChanges();
            }
        }
    }
}
