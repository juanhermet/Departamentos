using Departamentos.Infrastructure.Services;
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
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Departamentos.Controllers.AsignaturaC;
using Departamentos.Features.AsuntoC;
using Departamentos.Infrastructure;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Departamentos.Infrastructure.Persistents.Users;

namespace Departamentos
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
            services.AddTransient<IHostedService, ExpireDocumentoService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 4;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddIdentity<Usuarios, Roles>(options =>
            {
                options.User.RequireUniqueEmail = false;
            }

               ).AddEntityFrameworkStores<DepartamentosContext>().AddDefaultTokenProviders();

            ConfigureValidator(services);

            ConfigureSwagger(services);
            services.AddControllers()
                .AddFluentValidation();
            ConfigureDB(services);
            ConfigureMediatR(services);
        }
        private void ConfigureSwagger(IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "JHA Comparer API",
                    Description = "JHA Comparer API",
                });


                // Set the comments path for the Swagger JSON and UI.
                var apiXmlDocFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var apiXmlDocFilePath = Path.Combine(AppContext.BaseDirectory, apiXmlDocFileName);
                c.IncludeXmlComments(apiXmlDocFilePath);
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.CustomSchemaIds(type => type.ToString());
            });


        }

        private void ConfigureMediatR(IServiceCollection services)
        {
            services.AddMediatR(typeof(GetListOfAsignaturasQuery));
        }

        private void ConfigureValidator(IServiceCollection services)
        {
            //registra en el container de DI todos los tipos que esten contenidos en el assembly del tipo proporcionado
            services.AddValidatorsFromAssemblyContaining(typeof(CreateAsignaturaCommand.CommandValidator));
        }

        private void ConfigureDB(IServiceCollection services)
        {

            var connString = @"Server=127.0.0.1;Port=5432;Database=DepartamentosDb;User Id=postgres;Password=juan1234;";
            services.AddDbContext<DepartamentosContext>(opts =>
            {
                System.Diagnostics.Debug.WriteLine(Configuration.GetConnectionString(connString));
                opts.UseNpgsql(connString);
            });
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
    }
}
