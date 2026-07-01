using AutoMapper;
using EmployeeManagement.Application.DTOs.Employee;
using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeManagement.Application.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeRequest, Employee>();

            CreateMap<UpdateEmployeeRequest, Employee>();

            CreateMap<Employee, EmployeeResponse>()
                .ForMember(
                    dest => dest.DepartmentName,
                    opt => opt.MapFrom(src => src.Department!.Name));
        }
    }
}
