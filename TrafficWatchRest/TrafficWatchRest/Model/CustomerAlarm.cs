﻿using System;
using System.Collections.Generic;

namespace TrafficWatchRest.Model
{
    public partial class CustomerAlarm
    {
        public int CustomerId { get; set; }
        public int AlarmId { get; set; }

        public virtual Alarm Alarm { get; set; }
        public virtual Customer Customer { get; set; }
    }
}