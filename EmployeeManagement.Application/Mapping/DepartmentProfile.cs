using AutoMapper;
using EmployeeManagement.Application.DTOs.Department;
using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Mapping
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<CreateDepartmentRequest, Department>();

            CreateMap<Department, DepartmentResponse>();
        }
    }
}
