using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEventScheduler.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public int junk { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}