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
    public class AlarmController : ControllerBase
    {
        private static readonly string ConnectionString = Controllers.ConnectionString.GetConnectionString();

        private static Alarm ReadAlarm(IDataRecord reader)
        {
            int id = reader.GetInt32(0);
            DateTime wakeup = reader.GetDateTime(1);
            int delay = reader.GetInt32(2);
            Alarm alarm = new Alarm
            {
                Id = id,
                WakeUp = wakeup,
                Delay = delay,
            };
            return alarm;
        }
        // GET: api/Alarm
        [HttpGet]
        public IEnumerable<Alarm> GetAllAlarms()
        {
            const string selectString = "select * from alarm order by id";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<Alarm> alarmList = new List<Alarm>();
                        while (reader.Read())
                        {
                            Alarm alarm = ReadAlarm(reader);
                            alarmList.Add(alarm);
                        }
                        return alarmList;
                    }
                }
            }
        }

        // GET: api/Alarm/5
        [HttpGet("{id}", Name = "Get")]
        public Alarm GetAlarmById(int id)
        {
            const string selectString = "select * from alarm where id=@id";
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
                        return ReadAlarm(reader);
                    }
                }
            }
        }

        // POST: api/Alarm
        [HttpPost]
        public int AddAlarm([FromBody] Alarm value)
        {
            const string insertString = "insert into alarm (wakeup, delay) values (@wakeup, @delay)";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insertString, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@wakeup", value.WakeUp);
                    insertCommand.Parameters.AddWithValue("@delay", value.Delay);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // POST: api/Alarm
        [HttpPut("{id}")]
        public int UpdateAlarm(int id, [FromBody] Alarm value)
        {
            const string updateString =
                "update alarm set wakeup=@wakeup, delay=@delay;";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand updateCommand = new SqlCommand(updateString, databaseConnection))
                {
                    updateCommand.Parameters.AddWithValue("@wakeup", value.WakeUp);
                    updateCommand.Parameters.AddWithValue("@delay", value.Delay);
                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int DeleteAlarm(int id)
        {
            const string deleteStatement = "delete from alarm where id=@id";
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
