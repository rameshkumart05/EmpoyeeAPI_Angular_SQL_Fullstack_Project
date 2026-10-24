using EmpoyeeAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpoyeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMasterController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        private readonly ILogger<EmployeeMasterController> _logger;

        public EmployeeMasterController(
            EmployeeDbContext context,
            ILogger<EmployeeMasterController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // 1. GET: api/Employee
        // Get all employees
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var employees = await _context.Employees
                    .AsNoTracking()
                    .OrderBy(e => e.employeeid)
                    .ToListAsync();

                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving employees.");
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving employees."
                });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        message = "Please provide a valid email and password ."
                    });
                }

                string email = request.email.Trim();
                string password = request.contactNo.Trim();

                var employee = await _context.Employees  //.AsNoTracking()
                    .FirstOrDefaultAsync(e => e.email == email && e.contactNo == password);

                if (employee == null)
                {
                    return Unauthorized(new { message = "Invalid email or password." });
                }

                return Ok(new
                {
                    message = "Login successful.",
                    employee = new
                    {
                        employee.employeeid,
                        employee.name,
                        employee.email,
                        employee.contactNo,
                        employee.designationid,
                        employee.role
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during login.");

                return StatusCode(500, new
                {
                    message = "An unexpected error occurred."
                });
            }
        }

    }
}
