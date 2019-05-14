using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrafficWatchRest.Model;

namespace TrafficWatchRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private static readonly string ConnectionString = Controllers.ConnectionString.GetConnectionString();

        private static Route ReadRoute(IDataRecord reader)
        {
            int id = reader.GetInt32(0);
            int addressiddeparture = reader.GetInt32(1);
            int addressidarrival = reader.GetInt32(2);
            Route route = new Route()
            {
                Id = id,
                AddressIdDeparture = addressiddeparture,
                AddressIdArrival = addressidarrival
            };
            return route;
        }

        // GET: api/Route
        [HttpGet]
        public IEnumerable<Route> GetAllRoutes()
        {
            const string selectString = "select * from route order by id";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<Route> routeList = new List<Route>();
                        while (reader.Read())
                        {
                            Route route = ReadRoute(reader);
                            routeList.Add(route);
                        }

                        return routeList;
                    }
                }
            }
        }

        // GET: api/Route/5
        [HttpGet("{id}", Name = "Get")]
        public Route GetRouteById(int id)
        {
            const string selectString = "select * from route where id=@id";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    selectCommand.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.HasRows) { return null; }
                        reader.Read(); // advance cursor to first row
                        return ReadRoute(reader);
                    }
                }
            }
        }

        // POST: api/Route
        [HttpPost]
        public int AddRoute([FromBody] Route value)
        {
            const string insertString = "insert into route (addressiddeparture, addressidarrival) values (@addressiddeparture, @addressidarrival)";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insertString, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@addressiddeparture", value.AddressIdDeparture);
                    insertCommand.Parameters.AddWithValue("@addressiddeparture", value.AddressIdArrival);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // PUT: api/Route/5
        [HttpPut("{id}")]
        public int UpdateRoute(int id, [FromBody] Route value)
        {
            const string updateString =
                "update route set addressiddeparture=@addressiddeparture, addressidarrival=@addressidarrival;";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand updateCommand = new SqlCommand(updateString, databaseConnection))
                {
                    updateCommand.Parameters.AddWithValue("@email", value.AddressIdDeparture);
                    updateCommand.Parameters.AddWithValue("@firstname", value.AddressIdArrival);
                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int DeleteRoute(int id)
        {
            const string deleteStatement = "delete from route where id=@id";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(deleteStatement, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@id", id);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
    }
}
