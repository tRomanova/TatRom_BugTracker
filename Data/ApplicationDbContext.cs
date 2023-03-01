using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TatRom_BugTracker.Models;

namespace TatRom_BugTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<BTUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<BTUser> BTUsers { get; set; } = default!;
        public virtual DbSet<Company> Companies { get; set; } = default!;
        public virtual DbSet<Invite> Invites { get; set; } = default!;
        public virtual DbSet<Notification> Notifications { get; set; } = default!;
        public virtual DbSet<NotificationType> NotificationsType { get; set; } = default!;
        public virtual DbSet<Project> Projects { get; set; } = default!;
        public virtual DbSet<ProjectPriority> ProjectPriorities { get; set; } = default!;
        public virtual DbSet<Ticket> Tickets { get; set; } = default!;
        public virtual DbSet<TicketAttachment> TicketAttachments { get; set; } = default!;
        public virtual DbSet<TicketComment> TicketComments { get; set; } = default!;
        public virtual DbSet<TicketHistory> TicketHistory { get; set; } = default!;
        public virtual DbSet<TicketPriority> TicketPrioritis { get; set; } = default!;
        public virtual DbSet<TicketStatus> TicketStatus { get; set; } = default!;
        public virtual DbSet<TicketType> TicketType { get; set; } = default!;
    }                                     
}         