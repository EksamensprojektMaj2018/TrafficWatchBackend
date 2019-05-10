using System;
using System.Collections.Generic;
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
        private static List<Customer> customerList = new List<Customer>
        {
            new Customer(){Id = 1, Firstname = "Marcel", Lastname = "Kristensen", Email = "mar@mar.dk", AdresseID = 33, AlarmID = 8000, RouteID = 7, Admin = false},
            new Customer(),
            new Customer()
        };

        // GET: api/Customer
        [HttpGet]
        public List<Customer> Get()
        {
            return customerList;
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public Customer Get(int id)
        {
            return customerList.FirstOrDefault(x => x.Id == id);
        }

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
