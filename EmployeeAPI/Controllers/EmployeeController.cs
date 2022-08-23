using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private static List<Employee> _employees = new List<Employee>
    {
        new Employee
        {
            Id = 1,
            Name = "SAUVE Jean-Luc ",
            FirstName = "SAUVE",
            LastName = "Jean-Luc",
            Place = "Kigali"
        }
    };
    
    [HttpGet]
    public async Task<ActionResult<List<Employee>>> Get()
    {
        return Ok(_employees);
    }

    [HttpPost]
    public async Task<ActionResult<List<Employee>>> CreateEmployee(Employee employee)
    {
        _employees.Add(employee);
        return Ok(_employees);
    }

}