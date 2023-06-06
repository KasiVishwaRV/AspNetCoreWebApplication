using AspNetCoreWebApplication.Data.ViewModels;
using AspNetCoreWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Data.Services.Interafaces
{
  public interface IEmployeeService
  {
    void AddEmployee(EmployeeViewModel employeeViewModel);
    List<EmployeeModel> GetEmployees();
    List<EmployeeModel> SearchEmployee(string searchText);
    EmployeeModel GetEmployeesById(int EmpId);
    EmployeeModel UpdateEmployeeById(int EmpId, EmployeeViewModel employeeViewModel);
    EmployeeModel DeleteEmployeeById(int EmpId, EmployeeViewModel employeeViewModel);

  }
}
