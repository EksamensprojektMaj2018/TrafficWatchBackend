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
        //{
        //    new Customer(){Id = 1, Firstname = "Marcel", Lastname = "Kristensen", Email = "mar@mar.dk", AdresseID = 33, AlarmID = 8000, RouteID = 7, Admin = false},
        //    new Customer(),
        //    new Customer()
        //};

        //GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            const string selectString = "select * from customer order by id";
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

        private static Customer ReadCustomer(IDataRecord reader)
        {
            int id = reader.GetInt32(0);
            string email = reader.GetString(1);
            string firstname = reader.GetString(2);
            string lastname = reader.GetString(3);
            int addressid = reader.GetInt32(4);
            int alarmid = reader.GetInt32(5);
            int routeid = reader.GetInt32(6);
            bool admin = reader.GetBoolean(7);
            Customer customer = new Customer
            {
                Id = id,
                Email = email,
                FirstName = firstname,
                LastName = lastname,
                AddressId = addressid,
                AlarmId = alarmid,
                RouteId = routeid,
                Adminstartor = admin
            };
            return customer;
        }

        // GET: api/Customer/5
        //[HttpGet("{id}", Name = "Get")]
        //public Customer Get(int id)
        //{
        //    return 
        //}

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
