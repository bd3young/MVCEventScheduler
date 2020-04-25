using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCEventScheduler.Models;

namespace MVCEventScheduler.ViewModels
{
    public class EventIndexData
    {
        public IEnumerable<EventModel> Events { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }
    }
}