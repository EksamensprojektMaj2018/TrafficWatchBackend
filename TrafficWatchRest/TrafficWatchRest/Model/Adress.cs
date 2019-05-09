using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrafficWatchRest.Model
{
    public class Adress
    {
        public int Id { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string Road { get; set; }
        public int HouseNr { get; set; }
    }
}
