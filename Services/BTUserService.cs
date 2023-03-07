using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using TatRom_BugTracker.Data;
using TatRom_BugTracker.Models;
using TatRom_BugTracker.Services.Interfaces;

namespace TatRom_BugTracker.Services
{
    public class BTUserService : IBTUserService
    {
        private readonly ApplicationDbContext _context;
        public BTUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable> GetAllProjectsById(int id)
        {
            try
            {
                Company? company = await _context.Companies.Include(p => p.Projects).Where(c => c.Id == id).FirstOrDefaultAsync();

                return company!.Projects;
            }
            catch (Exception)
            {

                throw;
            }

            //throw new NotImplementedException();
        }
    }
}
