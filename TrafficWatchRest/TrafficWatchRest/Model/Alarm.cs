using System;
using System.Collections.Generic;

namespace TrafficWatchRest.Model
{
    public partial class Alarm
    {
        public int Id { get; set; }
        public DateTime WakeUp { get; set; }
        public int? Delay { get; set; }
    }
}