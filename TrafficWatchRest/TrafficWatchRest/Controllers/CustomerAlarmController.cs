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
    public class CustomerAlarmController : ControllerBase
    {
        private static readonly string ConnectionString = Controllers.ConnectionString.GetConnectionString();

        private static CustomerAlarm ReadCustomerAlarm(IDataRecord reader)
        {
            int customerid = reader.GetInt32(0);
            int alarmid = reader.GetInt32(1);
            CustomerAlarm customerAlarm = new CustomerAlarm()
            {
                CustomerId = customerid,
                AlarmId = alarmid,
            };
            return customerAlarm;
        }
        //GET: api/CustomerAlarm
        [HttpGet]
        public IEnumerable<CustomerAlarm> GetAllCustomerAlarms()
        {
            const string selectString = "select * from customerAlarm order by customer_id";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<CustomerAlarm> customerAlarmList = new List<CustomerAlarm>();
                        while (reader.Read())
                        {
                            CustomerAlarm customerAlarm = ReadCustomerAlarm(reader);
                            customerAlarmList.Add(customerAlarm);
                        }
                        return customerAlarmList;
                    }
                }
            }
        }

        // GET: api/CustomerAlarm/5
        [Route("{id}")]
        public CustomerAlarm GetCustomerAlarmById(int id)
        {
            const string selectString = "select * from customerAlarm where id=@customer_id";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    selectCommand.Parameters.AddWithValue("@customer_id", id);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.HasRows) { return null; }
                        reader.Read(); // advance cursor to first row
                        return ReadCustomerAlarm(reader);
                    }
                }
            }
        }

        // POST: api/CustomerAlarm
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CustomerAlarm/5
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
