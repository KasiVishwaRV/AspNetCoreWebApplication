using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Data.ViewModels
{
  public class EmployeeViewModel
  {
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfJoining { get; set; }
  }
}
