using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud2.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AppController : ControllerBase
    {
        private readonly Repositories.EmployeeRepository _employeeRepository;
        public AppController(Repositories.EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet("GetAllEmployees")]
        public ActionResult<List<Dto.Employee>> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return Ok(employees);
        }
        [HttpGet("GetEmployeeById/{id}")]
        public ActionResult<Dto.Employee> GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost("AddEmployee")]
        public ActionResult AddEmployee(Dto.Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
            return Ok();
        }
        [HttpPut("UpdateEmployee")]
        public ActionResult UpdateEmployee(Dto.Employee employee)
        {
            var existingEmployee = _employeeRepository.GetEmployeeById(employee.Id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            _employeeRepository.UpdateEmployee(employee);
            return Ok();
        }
        [HttpDelete("DeleteEmployee/{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var existingEmployee = _employeeRepository.GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            _employeeRepository.DeleteEmployee(id);
            return Ok();
        }
    }
}
