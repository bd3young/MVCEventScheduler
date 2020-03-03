using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCEventScheduler.Models
{
    public class EventModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the events name.")]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [StringLength(20, ErrorMessage = "The event type must be less than {1} characters")]
        [Display(Name = "Event Type")]
        public string EventType { get; set; }

        [Required(ErrorMessage = "Please enter the hosts name.")]
        [Display(Name = "Event Host")]
        public string EventHost { get; set; }

        [Required(ErrorMessage = "Please enter a Email")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "The Email field is not a valid Email")]
        public string Email { get; set; }
        public DateTime EventDateTime { get; set; }

        [Display(Name = "Public Event?")]
        public bool IsPublic { get; set; } = true;

        [Required(ErrorMessage = "Please enter the events Location.")]
        public string Location { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }

    }
}