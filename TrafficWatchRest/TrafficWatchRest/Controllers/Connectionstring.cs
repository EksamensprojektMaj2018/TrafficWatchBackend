namespace TrafficWatchRest.Controllers
{
    public static class ConnectionString
    {
        public static string GetConnectionString()
        {
            return
                "Server=tcp:razhorkserver.database.windows.net,1433;Initial Catalog=ExamDtabase;Persist Security Info=False;User ID=Razhork;Password=Password260196;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
    }
}