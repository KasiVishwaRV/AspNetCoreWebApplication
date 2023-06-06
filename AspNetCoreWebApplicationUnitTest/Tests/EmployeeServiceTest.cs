using AspNetCoreWebApplication;
using AspNetCoreWebApplication.Controllers;
using AspNetCoreWebApplication.Data.Services;
using AspNetCoreWebApplication.Data.Services.Interafaces;
using AspNetCoreWebApplication.Models;
using AutoFixture;
using FluentAssertions;
using Flurl.Http.Testing;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreWebApplicationUnitTest.Tests
{
  public class EmployeeServiceTest
  {
    private readonly IFixture _fixture;
    private readonly Mock<EmployeeService> _employeeServiceMock;
    private readonly MockRepository _mockRepository;
    private readonly AppDbContext _appDbContext;
    private readonly EmployeesController _employeesController;
    public EmployeeServiceTest()
    {
      _fixture = new Fixture();
      _mockRepository = new MockRepository(MockBehavior.Strict);
      _employeeServiceMock = _mockRepository.Create<EmployeeService>(_appDbContext);
      _employeesController = new EmployeesController(_employeeServiceMock.Object);
    }
    [Test]
    public void Create_Service()
    {
      // Arrange

      // Act

      // Assert
      _employeeServiceMock.Should().NotBeNull();

      _mockRepository.VerifyAll();
      _mockRepository.VerifyNoOtherCalls();
    }

    [Test]
    public void ShouldReturnAllEmployees()
    {
      //Arrange
      var employees = _fixture.CreateMany<EmployeeModel>().ToList();
      _employeeServiceMock.Setup(x => x.GetEmployees()).Returns(employees);

      //Act
      var result = _employeesController.GetEmploees();

      //Assert
      result.Should().NotBeNull();
      result.Should().BeAssignableTo<ActionResult<EmployeeModel>>();
      _employeeServiceMock.Verify(x => x.GetEmployees(), Times.Once);
    }
  }
}
