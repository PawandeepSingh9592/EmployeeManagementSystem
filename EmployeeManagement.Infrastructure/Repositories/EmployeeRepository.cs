using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeesAsync(
     string? search,
     int? departmentId,
     string? sortBy,
     bool isDescending,
     int pageNumber,
     int pageSize)
        {
            var query = _context.Employees
                .Include(x => x.Department)
                .Where(x => x.IsActive)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x =>
                    x.FirstName.Contains(search) ||
                    x.LastName.Contains(search) ||
                    x.Email.Contains(search));
            }

            if (departmentId.HasValue)
            {
                query = query.Where(x =>
                    x.DepartmentId == departmentId);
            }

            query = sortBy?.ToLower() switch
            {
                "salary" => isDescending
                    ? query.OrderByDescending(x => x.Salary)
                    : query.OrderBy(x => x.Salary),

                "joiningdate" => isDescending
                    ? query.OrderByDescending(x => x.JoiningDate)
                    : query.OrderBy(x => x.JoiningDate),

                _ => query.OrderBy(x => x.Id)
            };

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee employee)
        {
            _context.Employees.Update(employee);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Employees
                .AnyAsync(x => x.Email == email && x.IsActive);
        }
    }
}
