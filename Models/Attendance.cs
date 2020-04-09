using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCEventScheduler.Models
{
    public enum Status
    {
        NotAttending, MaybeAttending, Attending
    }
    public class Attendance
    {
        [Display(Name = "Attendance ID")]
        public int Id { get; set; }

        [Index]
        [Display(Name = "Event ID")]
        public int EventID { get; set; }

        [Index]
        [Display(Name = "User ID")]
        public int UserID { get; set; }
        public Status Status { get; set; }
        public virtual EventModel Event { get; set; }
        public virtual User User { get; set; }

    }
}