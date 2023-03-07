using System.ComponentModel.DataAnnotations;

namespace TatRom_BugTracker.Models
{
    public class Notification
    {
        public int Id { get; set; }

        // [FK] ProjectId (int)
        public int ProjectId { get; set; }

        // [FK] TicketId (int)
        public int TicketId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? Title { get; set; }

        [Required]
        [StringLength(5000, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? Message { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        //[FK] SenderId (string) [Required]
        [Required]
        public string? SenderId { get; set; }

        //[FK] RecipientId (string) [Required]
        [Required]
        public string? RecipientId { get; set; }

        //NotificationTypeId(int)
        public int NotificationTypeId { get; set; }
        public bool HasBeenViewed { get; set; }

        // navigation properties

        //NotificationType? ------------------------------------
        public virtual NotificationType? NotificationType { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public virtual Project? Project { get; set; }
        public virtual BTUser? Sender { get; set; }
        public virtual BTUser? Recipient { get; set; }
    }
}
