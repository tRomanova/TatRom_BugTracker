using System.ComponentModel.DataAnnotations;

namespace TatRom_BugTracker.Models
{
    public class Invite
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime InviteDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? JoinDate { get; set; }

        public Guid CompanyToken { get; set; }

        //[FK] CompanyId (int)
        public int CompanyId { get; set; }

        //[FK] ProjectId (int)
        public int ProjectId { get; set; }

        //[FK] InvitorId? (string)[Required]
        [Required]
        public string? InvitorId { get; set; }

        //[FK] InviteeId? (string)
        public string? InviteeId { get; set; }

        [Required]
        public string? InviteeEmail { get; set; }

        [Required]
        public string? InviteeFirstName { get; set; }

        [Required]
        public string? InviteeLastName { get; set; }

        [Required]
        [StringLength(600, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? Message { get; set; }

        public bool IsValid { get; set; }

        // Navigation properties
        public virtual Company? Company { get; set; }
        public virtual Project? Project { get; set; }
        public virtual BTUser? Invitor { get; set; }
        public virtual BTUser? Invitee { get; set; }
    }
}
