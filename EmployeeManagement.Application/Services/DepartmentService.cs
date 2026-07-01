using AutoMapper;
using EmployeeManagement.Application.DTOs.Department;
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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(
            IDepartmentRepository departmentRepository,
            IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<List<DepartmentResponse>> GetAllAsync()
        {
            var departments =
                await _departmentRepository.GetAllAsync();

            return _mapper.Map<List<DepartmentResponse>>(departments);
        }

        public async Task CreateAsync(CreateDepartmentRequest request)
        {
            var department =
                _mapper.Map<Department>(request);

            await _departmentRepository.AddAsync(department);
        }
    }
}
