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
    public class CustomerController : ControllerBase
    {
        private static readonly string ConnectionString = Controllers.ConnectionString.GetConnectionString();

        private static Customer ReadCustomer(IDataRecord reader)
        {
            int id = reader.GetInt32(0);
            string googleid = reader.GetString(1);
            string email = reader.GetString(2);
            string firstname = reader.GetString(3);
            string lastname = reader.GetString(4);
            int? addressid = reader.IsDBNull(5) ? 0: reader.GetInt32(5);
            int alarmid = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
            int routeid = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
            bool admin = reader.GetBoolean(8);
            Customer customer = new Customer(id, googleid, email, firstname, lastname, admin)
            {
                Id = id,
                GoogleId = googleid,
                Email = email,
                FirstName = firstname,
                LastName = lastname,
                AddressId = addressid,
                AlarmId = alarmid,
                RouteId = routeid,
                Administrator = admin
            };
            return customer;
        }

        //GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> GetAllCustomers()
        {
            const string selectString = "select id, google_id, email, first_name, last_name, address_id, alarm_id, route_id, administrator from Customer order by id";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<Customer> customerList = new List<Customer>();
                        while (reader.Read())
                        {
                            Customer customer = ReadCustomer(reader);
                            customerList.Add(customer);
                        }
                        return customerList;
                    }
                }
            }
        }

        // GET: api/Customer/5
        [Route("{id}")]
        public Customer GetCustomerById(int id)
        {
            const string selectString = "select * from customer where id=@id";
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
                        return ReadCustomer(reader);
                    }
                }
            }
        }
        // GET: api/Customer/5
        [Route("{googleId}")]
        public Customer GetCustomerByGoogleId(string googleId)
        {
            const string selectString = "select * from Customer where google_id=@googleid";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    selectCommand.Parameters.AddWithValue("@googleid", googleId);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.HasRows) { return null; }
                        reader.Read(); // advance cursor to first row
                        return ReadCustomer(reader);
                    }
                }
            }
        }

        // POST: api/Customer
        [HttpPost]
        public int InsertCustomer([FromBody] string googleId, string email, string firstName, string lastName, bool admin)
        {
            const string insertString = "insert into Customer (google_id, email, first_name, last_name, administrator) values (@googleid, @email, @firstname, @lastname, @admin)";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insertString, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@googleid", googleId);
                    insertCommand.Parameters.AddWithValue("@email", email);
                    insertCommand.Parameters.AddWithValue("@firstname", firstName);
                    insertCommand.Parameters.AddWithValue("@lastname", lastName);
                    insertCommand.Parameters.AddWithValue("@admin", admin);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public int UpdateCustomer([FromBody]int id, string email, string firstName, string lastName, int addressId, int alarmId, int routeId )
        {
            const string updateString =
                "update customer set email=@email, first_name=@firstname, last_name=@lastname, address_id=@addressid, alarm_id=@alarmid, route_id=@routeid where id=@id;";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand updateCommand = new SqlCommand(updateString, databaseConnection))
                {
                    updateCommand.Parameters.AddWithValue("@id", id);
                    updateCommand.Parameters.AddWithValue("@email", email);
                    updateCommand.Parameters.AddWithValue("@firstname", firstName);
                    updateCommand.Parameters.AddWithValue("@lastname", lastName);
                    updateCommand.Parameters.AddWithValue("@addressid", addressId);
                    updateCommand.Parameters.AddWithValue("@alarmid", alarmId);
                    updateCommand.Parameters.AddWithValue("@routeid", routeId);
                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int DeleteCustomer(int id)
        {
            const string deleteStatement = "delete from customer where id=@id";
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
