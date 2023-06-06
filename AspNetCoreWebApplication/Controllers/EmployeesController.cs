using AspNetCoreWebApplication.Data.Services;
using AspNetCoreWebApplication.Data.Services.Interafaces;
using AspNetCoreWebApplication.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase
  {
    private readonly IEmployeeService _employeeService;
    public EmployeesController(IEmployeeService employeeService)
    {
      _employeeService = employeeService;
    }

    [HttpPost("add-employee")]
    [HttpPost]  // localhost:5000?api/Employees POST With form data - ViewModel
    public IActionResult AddEmployee([FromBody] EmployeeViewModel employeeViewModel)
    {
      _employeeService.AddEmployee(employeeViewModel);
      return Ok();
    }

    [HttpGet("all-emps")]
    public IActionResult GetEmploees()
    {
      var emp = _employeeService.GetEmployees();
      return Ok(emp);
    }

    [HttpGet("all-emps-by-id/{id}")]
    public IActionResult GetEmploeesById(int id)
    {
      var emp = _employeeService.GetEmployeesById(id);
      return Ok(emp);
    }

    [HttpGet("search-emps-by-name")]
    public IActionResult SearchEmployees(string searchText)
    {
      var emp = _employeeService.SearchEmployee(searchText);
      return Ok(emp);
    }

    [HttpDelete("delete-emps-by-id/{id}")]
    public IActionResult DeleteEmploeesById(int id, [FromBody] EmployeeViewModel employeeViewModel)
    {
      var emp = _employeeService.DeleteEmployeeById(id, employeeViewModel);
      return Ok(emp);
    }

    [HttpPut("update-emps-by-id/{id}")]
    public IActionResult UpdateEmploeesById(int id, [FromBody] EmployeeViewModel employeeViewModel)
    {
      var emp = _employeeService.UpdateEmployeeById(id, employeeViewModel);
      return Ok(emp);
    }
  }
}
