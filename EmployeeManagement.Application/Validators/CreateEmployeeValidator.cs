using EmployeeManagement.Application.DTOs.Employee;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Validators
{
    public class CreateEmployeeValidator
     : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Mobile)
                .NotEmpty();

            RuleFor(x => x.Salary)
                .GreaterThan(0);

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0);
        }
    }
}
