using EmployeeManagement.Application.DTOs.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentResponse>> GetAllAsync();

        Task CreateAsync(CreateDepartmentRequest request);
    }
}
