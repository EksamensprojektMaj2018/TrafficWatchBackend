﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrafficWatchRest.Model
{
    public class CustomerAlarm : Customer
    {
        public int CustomerID { get; set; }
        public int AlarmID { get; set; }
    }
}
