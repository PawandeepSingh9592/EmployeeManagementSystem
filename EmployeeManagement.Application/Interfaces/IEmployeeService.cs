using EmployeeManagement.Application.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponse>> GetEmployeesAsync(
             string? search,
             int? departmentId,
             string? sortBy,
             bool isDescending,
             int pageNumber,
             int pageSize);
        Task<EmployeeResponse?> GetByIdAsync(int id);

        Task CreateAsync(CreateEmployeeRequest request);

        Task UpdateAsync(int id, UpdateEmployeeRequest request);

        Task DeleteAsync(int id);
    }
}
