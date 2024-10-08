using System.Data;
using Microsoft.Data.Sqlite;

namespace MinimalApi.DataBase;

public interface IDbConnectionFactory
{
    public Task<IDbConnection> CreateConnectionAsync();
}

public class SqlLiteConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public SqlLiteConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        return connection;
    }
}