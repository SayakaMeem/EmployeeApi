public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repo;
    public EmployeeService(IEmployeeRepository repo) => _repo = repo;
    public async Task<IEnumerable<EmployeeDto>> GetAllEmployees() { var emps = await _repo.GetAllAsync(); return emps.Select(e => new EmployeeDto(e.Id, e.Name, e.Age, e.Department)); }
    public async Task<EmployeeDto?> GetEmployee(int id) { var e = await _repo.GetByIdAsync(id); return e==null?null:new EmployeeDto(e.Id, e.Name, e.Age, e.Department); }
    public async Task<EmployeeDto> CreateEmployee(CreateEmployeeDto dto) { var emp = new Employee{Name=dto.Name, Age=dto.Age, Department=dto.Department}; var c = await _repo.AddAsync(emp); return new EmployeeDto(c.Id,c.Name,c.Age,c.Department); }
    public async Task<bool> DeleteEmployee(int id) => await _repo.DeleteAsync(id);
}