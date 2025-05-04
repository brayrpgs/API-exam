using Microsoft.Data.SqlClient;

class ConnectionSQL
{

    public static SqlConnection GetConnect()
    {
        String host = DotNetEnv.Env.GetString("HOST");
        Console.WriteLine($"HOST desde .env: {host}");
        return new SqlConnection();
    }
}