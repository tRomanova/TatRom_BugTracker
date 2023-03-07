using Microsoft.EntityFrameworkCore;
using TatRom_BugTracker.Data;
using TatRom_BugTracker.Models;
using TatRom_BugTracker.Services.Interfaces;

namespace TatRom_BugTracker.Services
{
	public class BTTicketSevice: IBTTicketService
	{
		private readonly ApplicationDbContext _context;
		public BTTicketSevice( ApplicationDbContext context) 
		{ 
			_context = context;	
		}

		public async Task<IEnumerable<Ticket>> GetAllTicketsByPrjectId(int id)
		{
			
			try
			{
					IEnumerable<Ticket> ticket = await _context.Tickets
															   .Include(c => c.Comments)
															   .Include(t => t.TicketType)
															   .Include(t => t.TicketStatus)
															   .Include(tp => tp.TicketPriority)
															   .Where(t => t.ProjectId == id)
															   .ToListAsync();
				
					return ticket;
			}
			catch (Exception)
			{

				throw;
			}

			//throw new NotImplementedException();
		}
	}
}
