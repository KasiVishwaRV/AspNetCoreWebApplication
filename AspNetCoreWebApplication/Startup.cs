using AspNetCoreWebApplication.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication
{
  public class Startup
  {
    public string ConnectionString { get; set; }
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
      ConnectionString = Configuration.GetConnectionString("DefaultConnectionString");
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddRazorPages();
      services.AddControllers();

      //Configure db context with sql database
      services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

      //Configure the services
      services.AddTransient<EmployeeService>();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Web_Api_Services", Version = "v2" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "Web_Api_Services v2"));
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapRazorPages();
      });
      AppDbInitializer.Seed(app);
    }
  }
}
