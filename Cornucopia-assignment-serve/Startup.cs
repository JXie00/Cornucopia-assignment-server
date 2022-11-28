using System.Net;
using Autofac;
using CornucopiaApi.Interfaces;
using CornucopiaApi.Services;
using Microsoft.OpenApi.Models;

namespace CornucopiaApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CornucopiaApi", Version = "v1" });
            c.EnableAnnotations();
        });
        services.AddControllers();
    }


    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterType<PhoneNumberService>().As<IPhoneNumberService>().InstancePerLifetimeScope();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CornucopiaApi v1"));
        }

        app.UseRouting();
        app.UseSwagger();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}