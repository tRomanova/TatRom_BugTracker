using System.ComponentModel.DataAnnotations;

namespace TatRom_BugTracker.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }

        [Display(Name = "Property Name")]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? PropertyName { get; set; }

        [StringLength(5000, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        [Display(Name = "Old Value")]
        [StringLength(5000, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? OldValue { get; set; }

        [Display(Name = "New Value")]
        [StringLength(5000, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? NewValue { get; set; }

        //[FK] TicketId (int)
        public int? TicketId { get; set; }

        [Required]
        public string? UserId { get; set; }

        // Navigation properties
        public virtual Ticket? Ticket { get; set; }
        public virtual BTUser? User { get; set; }
    }
}
