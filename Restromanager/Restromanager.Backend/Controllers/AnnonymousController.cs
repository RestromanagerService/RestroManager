using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.UnitsOfWork.interfaces;
using Restromanager.Backend.UnitsOfWork.Interfaces;
using System.Threading.Tasks;

namespace Restromanager.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnonymousController : ControllerBase
    {
        private readonly IOrdersHelper _ordersHelper;
        private readonly IOrderUnitOfWork _ordersUnitOfWork;

        public AnnonymousController(IOrdersHelper ordersHelper, IOrderUnitOfWork ordersUnitOfWork)
        {
            _ordersHelper = ordersHelper;
            _ordersUnitOfWork = ordersUnitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> PostAnAsync([FromBody] TemporalOrderFromLocalStorageDTO temporalOrder)
        {
            var response = await _ordersHelper.ProcessOrderAnAsync(temporalOrder.temporalOrders, temporalOrder.TableId);
            if (response.WasSuccess)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }
    }
}
