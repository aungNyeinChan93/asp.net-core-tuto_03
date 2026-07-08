using Microsoft.Data.SqlClient;
using System.Data;

namespace Tutorial.Dapper.Services.DapperService
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("Default"));
            return connection;
        }
    }
}
