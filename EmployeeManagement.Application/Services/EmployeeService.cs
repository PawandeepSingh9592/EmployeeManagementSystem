using AutoMapper;
using EmployeeManagement.Application.DTOs.Employee;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeResponse>> GetEmployeesAsync(
      string? search,
      int? departmentId,
      string? sortBy,
      bool isDescending,
      int pageNumber,
      int pageSize)
        {
            var employees =
                await _employeeRepository.GetEmployeesAsync(
                    search,
                    departmentId,
                    sortBy,
                    isDescending,
                    pageNumber,
                    pageSize);

            return _mapper.Map<List<EmployeeResponse>>(employees);
        }

        public async Task<EmployeeResponse?> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee is null)
            {
                return null;
            }

            return _mapper.Map<EmployeeResponse>(employee);
        }

        public async Task CreateAsync(CreateEmployeeRequest request)
        {
            var emailExists =
                await _employeeRepository.EmailExistsAsync(request.Email);

            if (emailExists)
            {
                throw new Exception("Email already exists.");
            }

            var department =
                await _departmentRepository.GetByIdAsync(request.DepartmentId);

            if (department is null)
            {
                throw new Exception("Department not found.");
            }

            var employee =
                _mapper.Map<Employee>(request);

            await _employeeRepository.AddAsync(employee);
        }

        public async Task UpdateAsync(
            int id,
            UpdateEmployeeRequest request)
        {
            var employee =
                await _employeeRepository.GetByIdAsync(id);

            if (employee is null)
            {
                throw new Exception("Employee not found.");
            }

            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.Mobile = request.Mobile;
            employee.DepartmentId = request.DepartmentId;
            employee.Salary = request.Salary;
            employee.JoiningDate = request.JoiningDate;
            employee.UpdatedDate = DateTime.UtcNow;

            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            var employee =
                await _employeeRepository.GetByIdAsync(id);

            if (employee is null)
            {
                throw new Exception("Employee not found.");
            }

            employee.IsActive = false;
            employee.UpdatedDate = DateTime.UtcNow;

            await _employeeRepository.DeleteAsync(employee);
        }
    }
}
