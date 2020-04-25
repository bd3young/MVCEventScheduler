using MVCEventScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEventScheduler.ViewModels
{
    public class AssignedAttendanceData
    {
        public int EventID { get; set; }
        //public string EventName { get; set; }
        public int UserID { get; set; }
        public Status Status { get; set; }
    }
}