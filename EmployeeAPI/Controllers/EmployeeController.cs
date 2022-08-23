using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var employees = new List<Employee>
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

        return Ok(employees);
    }
}