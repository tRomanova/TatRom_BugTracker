using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TatRom_BugTracker.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? Title { get; set; }

        [Required]
        [StringLength(5000, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Updated { get; set; }
        public bool Archived { get; set; }
        public bool ArchivedByProject { get; set; }

        //[FK] ProjectId (int)
        public int ProjectId { get; set; }

        //[FK] TicketTypeId (int)
        public int TicketTypeId { get; set; }

        //[FK] TicketStatusId (int)
        public int TicketStatusId { get; set; }

        //[FK] TicketPriorityId (int)
        public int TicketPriorityId { get; set; }

        //[FK] DeveloperUserId (string)
        public string? DeveloperUserId { get; set; }

        //[FK] SubmitterUserId (string) [Required]
        [Required]
        public string? SubmitterUserId { get; set; }

        // Navigation properties
        public virtual Project? Project { get; set; }
        public virtual TicketType? TicketType { get; set; }
        public virtual TicketStatus? TicketStatus { get; set; }
        public virtual TicketPriority? TicketPriority { get; set; }
        public virtual BTUser? DeveloperUser { get; set; }
        public virtual BTUser? SubmittedUser { get; set; }

        //Comments
        public virtual ICollection<TicketComment> Comments { get; set; } = new HashSet<TicketComment>();

        //Attachments
        public virtual ICollection<TicketAttachment> Attachments { get; set; } = new HashSet<TicketAttachment>();

        //History
        public virtual ICollection<TicketHistory> History { get; set; } = new HashSet<TicketHistory>();
    }
}
