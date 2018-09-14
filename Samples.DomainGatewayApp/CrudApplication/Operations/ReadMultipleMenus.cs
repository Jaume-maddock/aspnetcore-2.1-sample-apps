using AppDomain.Model.ExampleAggregate;
using AppDomain.Model.ExampleAggregate.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CrudApplication.Operations
{
    /// <summary>
    /// Multiple menu reads
    /// </summary>
    public class ReadMultipleMenus : IOperation
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ILoggerFactory _logger;

        /// <summary>
        /// Public Ctor
        /// </summary>
        /// <param name="menuRepository"></param>
        /// <param name="logger"></param>
        public ReadMultipleMenus(IMenuRepository menuRepository, ILoggerFactory logger)
        {
            _menuRepository = menuRepository ?? throw new ArgumentNullException(nameof(menuRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Loads a set of menus
        /// </summary>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        public async Task<ICollection<Menu>> ExecuteAsync(ICollection<int> menuIds)
        {
            var tasks = new List<Task<Menu>>();
            foreach (var id in menuIds)
            {
                tasks.Add(_menuRepository.Find(id));
            }
            await Task.WhenAll(tasks);
            _logger.CreateLogger(nameof(ReadMenu)).LogTrace($"Menus with id in {menuIds.ToString()} were retrieved");
            return tasks.Select(t => t.Result).ToList();
        }
    }
}
