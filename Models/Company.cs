using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TatRom_BugTracker.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Display(Name = "Company Name")]
        [Required]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? Name { get; set; }

        [StringLength(2000, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? Description { get; set; }

        //Image Properties
        public byte[]? ImageFileData { get; set; }
        public string? ImageFileType { get; set; }

        [NotMapped]
        public virtual IFormFile? ImageFormFile { get; set; }

        // navigation properties

        //Projects
        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();

        //Members
        public virtual ICollection<BTUser> Members { get; set; } = new HashSet<BTUser>();

        //Invites
        public virtual ICollection<Invite> Invites { get; set; } = new HashSet<Invite>();
    }
}
