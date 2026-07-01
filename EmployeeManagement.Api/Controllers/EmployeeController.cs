using EmployeeManagement.Application.DTOs.Employee;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(
            IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
     string? search,
     int? departmentId,
     string? sortBy,
     bool isDescending = false,
     int pageNumber = 1,
     int pageSize = 10)
        {
            var result =
                await _employeeService.GetEmployeesAsync(
                    search,
                    departmentId,
                    sortBy,
                    isDescending,
                    pageNumber,
                    pageSize);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =
                await _employeeService.GetByIdAsync(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateEmployeeRequest request)
        {
            await _employeeService.CreateAsync(request);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
    int id,
    UpdateEmployeeRequest request)
        {
            await _employeeService.UpdateAsync(id, request);

            return NoContent();
        }
    }
}
