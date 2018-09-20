using FlexibleSQLProvider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessQueryApi.Controllers
{
    [Route("api/business/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly BusinessRepository _businessRepository;

        public PromotionsController()
        {
            _businessRepository = new BusinessRepository();
        }

        [HttpGet("find")]
        public ActionResult<IEnumerable<string>> GetPromotions(int productId, string productType, DateTime startDate, DateTime endDate)
        {
            return _businessRepository.GetDynamicPromotions(productId, productType, startDate, endDate);
        }
    }
}
