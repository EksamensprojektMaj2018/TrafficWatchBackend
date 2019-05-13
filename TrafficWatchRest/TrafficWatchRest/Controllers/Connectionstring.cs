namespace TrafficWatchRest.Controllers
{
    public static class ConnectionString
    {
        public static string GetConnectionString()
        {
            return
                "Server=tcp:skoleservertest.database.windows.net,1433;Initial Catalog=eksamensdatabase;Persist Security Info=False;User ID=PowerTurtleDK;Password=TrafficDB1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
    }
}