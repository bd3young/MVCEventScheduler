using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEventScheduler.Models
{
    public enum Status
    {
        NotAttending, MaybeAttending, Attending
    }
    public class Attendance
    {

        public int AttendanceId { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public Status Status { get; set; }
        public virtual EventModel Event { get; set; }
        public virtual User User { get; set; }

    }
}