public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllEmployees();
    Task<EmployeeDto?> GetEmployee(int id);
    Task<EmployeeDto> CreateEmployee(CreateEmployeeDto dto);
    Task<bool> DeleteEmployee(int id);
}