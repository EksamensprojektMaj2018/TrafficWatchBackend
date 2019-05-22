using System;
using System.Collections.Generic;

namespace TrafficWatchRest.Model
{
    public partial class Address
    {
        public Address()
        {
            RouteAddressIdArrivalNavigation = new HashSet<Route>();
            RouteAddressIdDepartureNavigation = new HashSet<Route>();
        }

        public int Id { get; set; }
        public int? ZipCode { get; set; }
        public string City { get; set; }
        public string Road { get; set; }
        public int? HouseNr { get; set; }

        public virtual ICollection<Route> RouteAddressIdArrivalNavigation { get; set; }
        public virtual ICollection<Route> RouteAddressIdDepartureNavigation { get; set; }
    }
}