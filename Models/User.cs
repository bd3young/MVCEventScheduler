using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCEventScheduler.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a Username")]
        [MaxLength(12, ErrorMessage = "The maximum length is 12 characters")]
        [MinLength(3, ErrorMessage = "The minimum length is 3 characters")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [MaxLength(24, ErrorMessage = "The maximum length is 24 characters")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter a Email")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "The Email field is not a valid Email")]
        public string Email { get; set; }
        public int junk { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}