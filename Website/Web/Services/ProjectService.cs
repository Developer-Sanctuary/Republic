using Republic.Models;
using Republic.Web.Helpers;

namespace Republic.Web.Services
{
	public class ProjectService(HttpClient httpClient)
	{
		private readonly HttpClient _httpClient = httpClient;

		public async Task<List<Project>> GetProjectsAsync() => await _httpClient.GetFromJsonAsync<List<Project>>(GetApiEndpoint.GetProductionDefault());

		public async Task RegisterProjectAsync(Project project)
		{
			await _httpClient.PostAsJsonAsync(GetApiEndpoint.GetProductionDefault(), project);
		}
	}
}
