using AspNetCoreWebApplication.Data.Services;
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
    public EmployeeService _employeeService;
    public EmployeesController(EmployeeService employeeService)
    {
      _employeeService = employeeService;
    }

    [HttpPost("add-employee")]
    [HttpPost]  // localhost:5000?api/Employees POST With form data - ViewModel
    public IActionResult AddEmployee([FromBody]EmployeeViewModel employeeViewModel)
    {
      _employeeService.AddEmployee(employeeViewModel);
      return Ok();
    }

    [HttpGet]
    public IActionResult GetEmploees()
    {
      return Ok();
    }
  }
}
