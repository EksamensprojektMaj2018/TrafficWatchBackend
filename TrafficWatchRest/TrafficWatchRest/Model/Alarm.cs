using System;

namespace TrafficWatchRest.Model
{
    public class Alarm: CustomerAlarm
    {
        public int Id { get; set; }
        public DateTime WakeUP { get; set; }
        public int Delay { get; set; }
    }
}