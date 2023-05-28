using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Models
{
  public class EmployeeModel
  {
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    [Required]
    [MaxLength(30)]
    public string EmployeeName { get; set; }
    [Required]
    [MaxLength(30)]
    public string Email { get; set; }
    public DateTime DateOfJoining { get; set; }
  }
}
