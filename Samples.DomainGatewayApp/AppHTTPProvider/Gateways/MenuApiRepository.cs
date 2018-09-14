using AppDomain.Model.ExampleAggregate;
using AppDomain.Model.ExampleAggregate.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppHTTPProvider
{
    /// <summary>
    /// Routes for MenuApi
    /// </summary>
    internal static class MenuApiRouteConfig
    {
        public static string Find(int id) => $"/path/to/find/{id}";
        public static string Create() => $"/path/to/create/";
        public static string Delete(int id) => $"/path/to/delete/{id}";
    }

    /// <summary>
    /// Http repository implementation for a Menu Repository
    /// </summary>
    public class MenuApiRepository : IMenuRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MenuApiRepository> _logger;

        /// <summary>
        /// Public ctor. Requires dep. injection
        /// </summary>
        /// <param name="httpClient">HttpClient that requires at least a base address to work properly</param>
        /// <param name="logger">Logging interface</param>
        public MenuApiRepository(HttpClient httpClient, ILogger<MenuApiRepository> logger)
        {
            _httpClient = httpClient.BaseAddress != null ? httpClient : throw new TypeLoadException();
            _logger = logger ?? throw new TypeLoadException();
        }

        /// <summary>
        /// Finds an element in a remote Http repository
        /// </summary>
        /// <param name="id">Menu id</param>
        /// <returns></returns>
        public async Task<Menu> Find(int id)
        {
            var response = await _httpClient.GetAsync(MenuApiRouteConfig.Find(id));
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError(LogMessages.Error.UnknownProblem(id.ToString()));
                return null;
            }
            return await response.Content.ReadAsAsync<Menu>();
        }

        /// <summary>
        /// Creates an element 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public async Task<Menu> Create(Menu menu)
        {
            var response = await _httpClient.PostAsJsonAsync(MenuApiRouteConfig.Create(), menu);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError(LogMessages.Error.UnknownProblem(string.Empty));
                return null;
            }
            return await response.Content.ReadAsAsync<Menu>();
        }

        /// <summary>
        /// Deletes an element
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
            {
                _logger.LogError(LogMessages.Error.InvalidInput());
                return false;
            }
            var response = await _httpClient.DeleteAsync(MenuApiRouteConfig.Delete(id));
            return response.IsSuccessStatusCode;
        }

    }
}
