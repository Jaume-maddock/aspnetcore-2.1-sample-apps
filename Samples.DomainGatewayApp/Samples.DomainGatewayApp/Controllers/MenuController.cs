using AppDomain.Model.ExampleAggregate;
using AppDomain.Model.ExampleAggregate.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Samples.DomainGatewayApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        /// <summary>
        /// Retrieves a Menu from its ID. Usage: GET api/menu/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Menu), 200), ProducesResponseType(400), ProducesResponseType(typeof(void), 404)]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            return await _menuRepository.Find(id);
        }
    }
}
