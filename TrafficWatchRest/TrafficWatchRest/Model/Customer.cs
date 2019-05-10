﻿namespace TrafficWatchRest.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int AdresseID { get; set; }
        public int AlarmID { get; set; }
        public int RouteID { get; set; }
        public bool Admin { get; set; }

    }
}