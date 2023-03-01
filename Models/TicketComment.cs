using System.ComponentModel.DataAnnotations;

namespace TatRom_BugTracker.Models
{
    public class TicketComment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(600, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? Comment { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        //[FK] TicketId (int)
        public int TicketId { get; set; }

        //[FK] UserId (string)
        public string? UserId { get; set; }

        // Navigation properties
        public virtual Ticket? Ticket { get; set; }
        public virtual BTUser? User { get; set; }
    }
}
