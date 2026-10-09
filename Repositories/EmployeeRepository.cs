using Microsoft.EntityFrameworkCore;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;
    public EmployeeRepository(AppDbContext context) => _context = context;
    public async Task<List<Employee>> GetAllAsync() => await _context.Employees.ToListAsync();
    public async Task<Employee?> GetByIdAsync(int id) => await _context.Employees.FindAsync(id);
    public async Task<Employee> AddAsync(Employee emp) { _context.Employees.Add(emp); await _context.SaveChangesAsync(); return emp; }
    public async Task<bool> DeleteAsync(int id) { var e = await GetByIdAsync(id); if(e==null) return false; _context.Employees.Remove(e); await _context.SaveChangesAsync(); return true; }
}