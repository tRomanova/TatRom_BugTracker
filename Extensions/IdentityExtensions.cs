using System.Security.Claims;
using System.Security.Principal;

namespace TatRom_BugTracker.Extensions
{
	public static class IdentityExtensions
	{
		public static int GetCompanyId(this IIdentity identity)
		{
			//we will take identity and cast it as ClaimsIdentity
			Claim claim = ((ClaimsIdentity)identity).FindFirst("CompanyId")!;
			return int.Parse(claim.Value);
		}
	}
}
