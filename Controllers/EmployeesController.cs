using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _service;
    public EmployeesController(IEmployeeService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllEmployees());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var emp = await _service.GetEmployee(id);
        return emp == null? NotFound() : Ok(emp);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeDto dto)
    {
        var created = await _service.CreateEmployee(dto);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteEmployee(id);
        return result? NoContent() : NotFound();
    }
}