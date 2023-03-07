using TatRom_BugTracker.Models;

namespace TatRom_BugTracker.Services.Interfaces
{
	public interface IBTTicketService
	{
		public  Task<IEnumerable<Ticket>> GetAllTicketsByPrjectId(int id);
	}
}
