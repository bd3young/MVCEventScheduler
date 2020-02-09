using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEventScheduler.Models
{
    public class EventModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public string EventHost { get; set; }
        public string Email { get; set; }
        public DateTime EventDateTime { get; set; }
        public bool IsPublic { get; set; } = true;
        public string Location { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }

    }
}