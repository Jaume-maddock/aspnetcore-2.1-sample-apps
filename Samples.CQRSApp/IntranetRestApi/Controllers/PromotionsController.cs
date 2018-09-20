using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleDomainSimple;
using SampleDomainSimple.Model.PromotionAggregate.Repositories;

namespace IntranetRestApi.Controllers
{
    [Route("api/management/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionsController(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Promotion>), 200), ProducesResponseType(400), ProducesResponseType(typeof(void), 404)]
        public ActionResult<IEnumerable<Promotion>> Get()
        {
            return Ok(_promotionRepository.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Promotion> Get(int id)
        {
            return _promotionRepository.Find(id);
        }

        // POST api/values
        [HttpPost]
        public int Post([FromBody] Promotion value)
        {
            return _promotionRepository.Create(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Promotion value)
        {
            return _promotionRepository.Modify(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _promotionRepository.Delete(id);
        }
    }
}
