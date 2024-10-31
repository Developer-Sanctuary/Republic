using Republic.Helpers;

namespace Republic.Web.Helpers
{
	public class GetApiEndpoint
	{
		public static string GetProductionDefault() => $"https+http://localhost:7430/v{GetVersion.GetApiVersion()}";
	}
}
