using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Dapper.Feaatures.Employees.ReqResModels;

namespace Tutorial.Dapper.Feaatures.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var response = await _employeeService.GetAllEmployees();
            return Ok(response);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute]int id)
        {
            var response = await _employeeService.GetEmployeeById(id);
            return Ok(response);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateEmployee([FromBody]EmployeeCreateRequestModel reqModel)
        {
            var response = await _employeeService.CreateEmployee(reqModel);
            return Ok(response >= 1 ? "success" : "fail");
        }
    }
}
