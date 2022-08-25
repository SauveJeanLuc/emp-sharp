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
            Id = 2,
            Name = " Kabeza Rebero ",
            FirstName = "Kabeza",
            LastName = "Rebero",
            Place = "Kabeza"
        },
    };

    private readonly DataContext _context;
    public EmployeeController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<List<Employee>>> Get()
    {
        return Ok(await _context.Employees.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> Get(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        // var employee = _employees.Find(h => h.Id == id);
        
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

    [HttpPut]
    public async Task<ActionResult<Employee>> UpdateEmployee(Employee request)
    {
        var employee = _employees.Find(h => h.Id == request.Id);
        if (employee == null)
        {
            return BadRequest("Employee to update does not exist.");
        }
        employee.Name = request.Name;
        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.Place = request.Place;

        return Ok(employee);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
    {
        var employee = _employees.Find(h => h.Id == id);
        if (employee == null)
            return BadRequest("Employee not Found");

        _employees.Remove(employee);
        return Ok(employee);
    }


}