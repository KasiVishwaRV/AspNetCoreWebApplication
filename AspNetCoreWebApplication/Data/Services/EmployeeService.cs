using AspNetCoreWebApplication.Data.ViewModels;
using AspNetCoreWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Data.Services
{
  public class EmployeeService
  {
    private AppDbContext _appDbContext;
    public EmployeeService(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }
    public void AddEmployee(EmployeeViewModel employeeViewModel)
    {
      var _employee = new EmployeeModel()
      {
        Email = employeeViewModel.Email,
        EmployeeId = employeeViewModel.EmployeeId,
        EmployeeName = employeeViewModel.EmployeeName,
        DateOfJoining = DateTime.Now
      };
      _appDbContext.Employees.Add(_employee);
      _appDbContext.SaveChanges();
    }
  }
}
