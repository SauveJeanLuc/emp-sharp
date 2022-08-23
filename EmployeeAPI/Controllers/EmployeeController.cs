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
        },
        new Employee
        {
            Id = 1,
            Name = " Kabeza Rebero ",
            FirstName = "Kabeza",
            LastName = "Rebero",
            Place = "Kabeza"
        },
    };
    
    [HttpGet]
    public async Task<ActionResult<List<Employee>>> Get()
    {
        return Ok(_employees);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> Get(int id)
    {
        var employee = _employees.Find(h => h.Id == id);
        
        if (employee == null)
            return BadRequest("Employee Not Found");
        
        return Ok(employee);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<Employee>>> CreateEmployee(Employee employee)
    {
        _employees.Add(employee);
        return Ok(_employees);
    }

}