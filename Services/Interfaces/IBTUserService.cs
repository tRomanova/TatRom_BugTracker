using System.Collections;

namespace TatRom_BugTracker.Services.Interfaces
{
    public interface IBTUserService
    {
        public Task<IEnumerable> GetAllProjectsById(int id);
    }
}
