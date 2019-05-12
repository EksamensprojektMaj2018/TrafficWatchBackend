using System.Data.SqlClient;

namespace TrafficWatchRest.Controllers
{
    public class ConnectionString
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Server=tcp:skoleservertest.database.windows.net,1433;Initial Catalog=eksamensdatabase;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        conn
    }
}