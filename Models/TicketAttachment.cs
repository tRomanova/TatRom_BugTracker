using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TatRom_BugTracker.Models
{
    public class TicketAttachment
    {
        public int Id { get; set; }

        [StringLength(600, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        //[FK] TicketId (int)
        public int TicketId { get; set; }

        //[FK] BTUserId (string) [Required]
        [Required]
        public string? BTUserId { get; set; }

        //Image Properties
        public byte[]? ImageData { get; set; }
        public string? ImageType { get; set; }

        [NotMapped]
        public virtual IFormFile? ImageFile { get; set; }

        //Navigation properties
        public virtual Ticket? Ticket { get; set; }
        public virtual BTUser? BTUser { get; set; }
    }
}
