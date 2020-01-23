using System;

namespace MVCEventScheduler.Models
{
    public class EventModel
    {

        public string EventName { get; set; }
        public string EventHost { get; set; }
        public string Email { get; set; }
        public DateTime EventDateTime { get; set; }
        public int Id { get; set; }
        public bool IsPublic { get; set; } = true;


    }
}