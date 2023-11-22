using System.Data;
using System.Data.SQLite;
using Dapper;

namespace BlazorAppWithMediatrAndDapper.DAL.Repositories;

public class BaseRepository
{
	private string? _connectionString;
	private string ConnectionString {
		get
		{
			if (_connectionString == null)
			{
				_connectionString = GetConnectionString();
			}
			return _connectionString;
		}}

	protected async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters = null)
	{
		using (var connection = CreateConnectionQuery())
		{
			connection.Open();
			return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
		}
	}

	protected async Task<List<T>> QueryAsync<T>(string sql, object parameters = null)
	{
		using (var connection = CreateConnectionQuery())
		{
			connection.Open();
			var result = await connection.QueryAsync<T>(sql, parameters);
			return result.ToList();
		}
	}

	protected async Task<int> ExecuteAsync(string sql, object parameters = null)
	{
		using (var connection = CreateConnectionCommand())
		{
			connection.Open();
			return await connection.ExecuteAsync(sql, parameters);
		}
	}

	// For CQRS we can use different databases for readind and writing data.
	protected IDbConnection CreateConnectionQuery()
	{
		return new SQLiteConnection(ConnectionString);
	}
	protected IDbConnection CreateConnectionCommand()
	{
		return new SQLiteConnection(ConnectionString);
	}

	private string GetConnectionString()
	{
		string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
		string databasePath = Path.Combine(currentDirectory, "orders_data.db");
		return $"Data Source={databasePath};Version=3;";
	}
}
