namespace TokenGenerator.Api
{
    using System;
    using System.IO;
    using Infra.Contexts;
    using Domain.Handlers;
    using System.Reflection;
    using Infra.Repositories;
    using Domain.Repositories;
    using Microsoft.OpenApi.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddTransient<ICustomerCardRepository, CustomerCardRepository>();
            services.AddTransient<CreateCustomerCardHandler, CreateCustomerCardHandler>();
            services.AddTransient<ValidateCustomerCardHandler, ValidateCustomerCardHandler>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo 
                    { 
                        Title = "Token Generator", 
                        Version = "v1",
                        Description = "Sample API used to generate a token for cashless registration"
                    }
                );

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                x.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Token Generator - v1");
            });
        }
    }
}
