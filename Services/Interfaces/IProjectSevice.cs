using System.Collections;
using TatRom_BugTracker.Models;

namespace TatRom_BugTracker.Services.Interfaces
{
	public interface IProjectSevice
	{
		public Task<IEnumerable> GetAllProjectsByUserId(string projectId);
		public Task<Project> GetProjectById(int id);
	}
}
