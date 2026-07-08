using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Dapper.Models;
using Tutorial.Dapper.Services.DapperService;

namespace Tutorial.Dapper.Feaatures.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IDapperService _dapperService;

        private readonly ILogger<CustomersController> _logger;

        public CustomersController(IDapperService dapperService, ILogger<CustomersController> logger)
        {
            _dapperService = dapperService;
            _logger = logger;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var query = @"select * from Sales.Customers";
            var response = await _dapperService.QueryAsync<Customer>(query);
            return Ok(response);
        }
    }
}
