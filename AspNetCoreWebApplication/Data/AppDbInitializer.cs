using AspNetCoreWebApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication
{
  public class AppDbInitializer
  {
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
      using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
        if (!context.Employees.Any())
        {
          context.Employees.AddRange(new EmployeeModel()
          {
            Email = "Employee1@gmail.com",
            DateOfJoining = DateTime.Today.AddDays(-5),
            EmployeeName = "Employee1"
          }, new EmployeeModel()
          {
            Email = "Employee2@gmail.com",
            DateOfJoining = DateTime.Today,
            EmployeeName = "Employee2"
          });
          context.SaveChanges();
        }
      }
    }
  }
}
