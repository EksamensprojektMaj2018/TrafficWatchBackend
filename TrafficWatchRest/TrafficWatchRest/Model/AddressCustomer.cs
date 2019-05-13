using System;
using System.Collections.Generic;

namespace TrafficWatchRest.Model
{
    public partial class AddressCustomer
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
    }
}