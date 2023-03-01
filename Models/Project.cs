using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TatRom_BugTracker.Models
{
    public class Project
    {
        public int Id { get; set; }

        //[FK] CompanyId (int)
        public int CompanyId { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? Name { get; set; }

        [Required]
        [StringLength(600, ErrorMessage = "The {0} must be at least {2} and at most {1} characters", MinimumLength = 2)]
        public string? Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        //ProjectPriorityId
        public int ProjectPriorityId { get; set; }

        //Image Properties
        public byte[]? ImageData { get; set; }
        public string? ImageType { get; set; }

        [NotMapped]
        public virtual IFormFile? ImageFile { get; set; }

        public bool Archived { get; set; }

        //Navigation properties
        public virtual Company? Company { get; set; }
        public virtual ProjectPriority? ProjectPriority { get; set; }

        // Members
        [JsonIgnore]
        public virtual ICollection<BTUser> Members { get; set; } = new HashSet<BTUser>();

        // Tickets
        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
