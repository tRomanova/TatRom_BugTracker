using Microsoft.EntityFrameworkCore;
using System.Collections;
using TatRom_BugTracker.Data;
using TatRom_BugTracker.Models;
using TatRom_BugTracker.Services.Interfaces;

namespace TatRom_BugTracker.Services
{
    public class ProjectService : IProjectSevice
    {
        private readonly ApplicationDbContext _context;
        public ProjectService(ApplicationDbContext context) 
        { 
            _context = context;
        }
        public Task<IEnumerable> GetAllProjectsByUserId(string projectId)
        {
           
            throw new NotImplementedException();
        }

        public async Task<Project> GetProjectById(int id)
        {
			Project? project = await _context.Projects.Where(p => p.CompanyId == id)
											.Include(p => p.Company)
											.Include(p => p.ProjectPriority)
											.Include(p => p.ProjectPriority)
											.Include(p => p.Tickets)
												.ThenInclude(t => t.DeveloperUser)
											.Include(p => p.Tickets)
												.ThenInclude(t => t.SubmittedUser)
											.FirstOrDefaultAsync(m => m.Id == id);

            return project!;
		}

	}
}
