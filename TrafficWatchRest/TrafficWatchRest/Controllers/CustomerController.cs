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
            Customer customer = new Customer
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
        //[Route("{id}")]
        //public Customer GetCustomerById(int id)
        //{
        //    const string selectString = "select * from customer where id=@id";
        //    using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
        //    {
        //        databaseConnection.Open();
        //        using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
        //        {
        //            selectCommand.Parameters.AddWithValue("@id", id);
        //            using (SqlDataReader reader = selectCommand.ExecuteReader())
        //            {
        //                if (!reader.HasRows) { return null; }
        //                reader.Read(); // advance cursor to first row
        //                return ReadCustomer(reader);
        //            }
        //        }
        //    }
        //}
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
        public int AddCustomer([FromBody] Customer value)
        {
            const string insertString = "insert into Customer (google_id, email, first_name, last_name, address_id, alarm_id, route_id, administrator) values (@googleid, @email, @firstname, @lastname, @addressid, @alarmid, @routeid, @admin)";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insertString, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@googleid", value.GoogleId);
                    insertCommand.Parameters.AddWithValue("@email", value.Email);
                    insertCommand.Parameters.AddWithValue("@firstname", value.FirstName);
                    insertCommand.Parameters.AddWithValue("@lastname", value.LastName);
                    insertCommand.Parameters.AddWithValue("@addressid", value.AddressId);
                    insertCommand.Parameters.AddWithValue("@alarmid", value.AlarmId);
                    insertCommand.Parameters.AddWithValue("@routeid", value.RouteId);
                    insertCommand.Parameters.AddWithValue("@admin", value.Administrator);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public int UpdateCustomer(int id, [FromBody] Customer value)
        {
            const string updateString =
                "update customer set email=@email, firstname=@firstname, lastname=@lastname, addressid=@addressid, alarmid=@alarmid routeid=@routeid, admin=@admin where id=@id;";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand updateCommand = new SqlCommand(updateString, databaseConnection))
                {
                    updateCommand.Parameters.AddWithValue("@email", value.Email);
                    updateCommand.Parameters.AddWithValue("@firstname", value.FirstName);
                    updateCommand.Parameters.AddWithValue("@lastname", value.LastName);
                    updateCommand.Parameters.AddWithValue("@addressid", value.AddressId);
                    updateCommand.Parameters.AddWithValue("@alarmid", value.AlarmId);
                    updateCommand.Parameters.AddWithValue("@routeid", value.RouteId);
                    updateCommand.Parameters.AddWithValue("@admin", value.Administrator);
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
