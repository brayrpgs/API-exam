using Microsoft.Data.SqlClient;

class ConnectionSQL
{

    protected static SqlConnection GetConnect()
    {
        String host = DotNetEnv.Env.GetString("HOST");
        return new SqlConnection();
    }
}