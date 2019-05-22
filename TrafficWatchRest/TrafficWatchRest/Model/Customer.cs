using System;
using System.Collections.Generic;

namespace TrafficWatchRest.Model
{
    public partial class Customer
    {
        public Customer()
        {
            AddressCustomer = new HashSet<AddressCustomer>();
            CustomerAlarm = new HashSet<CustomerAlarm>();
        }

        public int Id { get; set; }
        public string GoogleId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AddressId { get; set; }
        public int? AlarmId { get; set; }
        public int? RouteId { get; set; }
        public bool Administrator { get; set; }

        public virtual ICollection<AddressCustomer> AddressCustomer { get; set; }
        public virtual ICollection<CustomerAlarm> CustomerAlarm { get; set; }
    }
}