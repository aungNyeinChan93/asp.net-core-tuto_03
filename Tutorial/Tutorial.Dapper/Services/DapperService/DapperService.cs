using Dapper;
using System.Data;

namespace Tutorial.Dapper.Services.DapperService
{
    public class DapperService : IDapperService
    {
        private readonly DapperContext _context;

        public DapperService(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null!, CommandType? commandType = CommandType.Text)
        {
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<T>(sql, param, commandType: commandType);
            return result;
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = default!, CommandType? commandType = CommandType.Text)
        {
            using var connection = _context.CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<T>(sql, param, commandType: commandType);
            return result!;
        }

        public async Task<int> ExecuteAsync(
           string sql,
           object? param = null,
           CommandType commandType = CommandType.Text)
        {
            using var connection = _context.CreateConnection();

            var result = await connection.ExecuteAsync(
                sql,
                param,
                commandType: commandType);

            return result;
        }

    }
}
