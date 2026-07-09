using Dapper;
using Dapper.Database.Database.AppDbContext.Models;
using System.Data;
using Tutorial.Dapper.Feaatures.Employees.ReqResModels;
using Tutorial.Dapper.Models;
using Tutorial.Dapper.Services.DapperService;

namespace Tutorial.Dapper.Feaatures.Employees
{
    public class EmployeeService
    {
        private readonly IDapperService _dapperService;

        public EmployeeService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var response = await _dapperService.QueryAsync<EmployeeModel>(
                "Sp_GetAllEmployees",commandType:CommandType.StoredProcedure);
            return response.ToList();
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {

            var parameter = new DynamicParameters();
            parameter.Add("@EmployeeId", id);

            var response = await _dapperService.QueryFirstOrDefaultAsync<EmployeeModel>(
                "Sp_GetEmployeeById",parameter,commandType:CommandType.StoredProcedure);

            return response;
        }

        public async Task<int> CreateEmployee(EmployeeCreateRequestModel reqModel)
        {
            var response = await _dapperService.ExecuteAsync(
                "Sp_CreateEmployee", reqModel,commandType:CommandType.StoredProcedure);

            return response;
        }
    }
}
