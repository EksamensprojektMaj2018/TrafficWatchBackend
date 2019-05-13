using System;
using System.Collections.Generic;

namespace TrafficWatchRest.Model
{
    public partial class Route
    {
        public int Id { get; set; }
        public int? AddressIdDeparture { get; set; }
        public int? AddressIdArrival { get; set; }

        public virtual Address AddressIdArrivalNavigation { get; set; }
        public virtual Address AddressIdDepartureNavigation { get; set; }
    }
}