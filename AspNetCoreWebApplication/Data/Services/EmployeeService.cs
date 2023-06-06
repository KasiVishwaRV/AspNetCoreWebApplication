using AspNetCoreWebApplication.Data.Services.Interafaces;
using AspNetCoreWebApplication.Data.ViewModels;
using AspNetCoreWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Data.Services
{
  public class EmployeeService : IEmployeeService
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

    public List<EmployeeModel> GetEmployees() => _appDbContext.Employees.OrderBy(x => x.Id).ToList();
    public List<EmployeeModel> SearchEmployee(string searchText)
    {
      return _appDbContext.Employees.Where(x => x.EmployeeName.ToLower().Contains(searchText.ToLower())).ToList();
    }
    public EmployeeModel GetEmployeesById(int EmpId) => _appDbContext.Employees.FirstOrDefault(e => e.Id == EmpId);
    public EmployeeModel UpdateEmployeeById(int EmpId, EmployeeViewModel employeeViewModel)
    {
      var _employee = _appDbContext.Employees.FirstOrDefault(e => e.Id == EmpId);
      if (_employee != null)
      {
        _employee.EmployeeId = employeeViewModel.EmployeeId;
        _employee.Email = employeeViewModel.Email;
        _employee.EmployeeName = employeeViewModel.EmployeeName;
        _employee.DateOfJoining = DateTime.Now;


        _appDbContext.SaveChanges();
      }
      return _employee;
    }

    public EmployeeModel DeleteEmployeeById(int EmpId, EmployeeViewModel employeeViewModel)
    {
      var _employee = _appDbContext.Employees.FirstOrDefault(e => e.Id == EmpId);
      if (_employee != null)
      {
        _appDbContext.Remove(_employee);
        _appDbContext.SaveChanges();
      }
      return _employee;
    }
  }
}
