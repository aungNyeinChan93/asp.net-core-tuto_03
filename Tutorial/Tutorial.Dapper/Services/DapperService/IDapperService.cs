using System.Data;

namespace Tutorial.Dapper.Services.DapperService
{
    public interface IDapperService
    {
        Task<int> ExecuteAsync(string sql, object? param = null, CommandType commandType = CommandType.Text);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, CommandType? commandType = CommandType.Text);
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, CommandType? commandType = CommandType.Text);
    }
}