using AppDomain.Model.ExampleAggregate;
using AppDomain.Model.ExampleAggregate.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrudApplication.Operations
{
    public class ReadMenuOperation : IOperation
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ILoggerFactory _logger;

        public ReadMenuOperation(IMenuRepository menuRepository, ILoggerFactory logger)
        {
            _menuRepository = menuRepository ?? throw new ArgumentNullException(nameof(menuRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<Menu> ExecuteAsync(int menuId)
        {
            var menu = await _menuRepository.Find(menuId);
            _logger.CreateLogger(nameof(ReadMenu)).LogTrace($"Menu with id {menuId} was retrieved");
            return menu;
        }
    }
}
