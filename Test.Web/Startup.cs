using System;
using System.IO;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Test.Application;
using Test.Application.Behaviors;
using Test.Application.CustomValidations;
using Test.Infrastructure;

namespace Test.Api
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
            services.AddDbContext<IAppDbContext, AppDbContext>(options =>
            {
                options.EnableSensitiveDataLogging();

                var connection = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connection).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.Scan(scan => scan
                .FromApplicationDependencies(assembly => !assembly.Equals(typeof(IValidator).Assembly))
                .AddClasses(f => f.AssignableTo(typeof(IValidator)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            //services.AddFluentValidation().AddValidatorsFromAssemblyContaining(typeof(CustomAbstractValidator<>));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers(opt=> opt.Filters.Add(new ExceptionFilter()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test.Api", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test.Web v1"));
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
