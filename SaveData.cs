
using Npgsql;

public class SaveData
{
    public SaveData() { }
    public static string postgresConnectionString = "";
    public async Task<List<string>> GrabData()
    {
        var connectionString = "Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase";
        await using var dataSource = NpgsqlDataSource.Create(connectionString);

        await using (var cmd = dataSource.CreateCommand("INSERT INTO data (some_field) VALUES ($1)"))
        {
            cmd.Parameters.AddWithValue("Hello world");
            await cmd.ExecuteNonQueryAsync();
        }
        int total = 0;

        await using (var cmd = dataSource.CreateCommand("SELECT COUNT(some_field) FROM data"))
        {
            total = (int?) await cmd.ExecuteScalarAsync() ?? 0;
        }
        return new List<string>();
    }
}
