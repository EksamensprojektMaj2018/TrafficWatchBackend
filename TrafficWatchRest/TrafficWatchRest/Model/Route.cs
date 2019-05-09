using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrafficWatchRest.Model
{
    public class Route : Customer
    {
        public int Id { get; set; }
        public int addressIdDepature { get; set; }
        public int addressIdArrival { get; set; }
    }
}
