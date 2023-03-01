using System.ComponentModel.DataAnnotations;

namespace TatRom_BugTracker.Models
{
    public class TicketStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? Name { get; set; }
    }
}
