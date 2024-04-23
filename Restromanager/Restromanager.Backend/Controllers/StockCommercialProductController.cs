using Microsoft.AspNetCore.Mvc;
using Orders.DTOs;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockCommercialProductController(IGenericUnitOfWork<StockCommercialProduct> unitOfWork, IStockCommercialProductUnitOfWork stockUnitOfWork) : GenericController<StockCommercialProduct>(unitOfWork)
    {
        private readonly IStockCommercialProductUnitOfWork _unitOfWork = stockUnitOfWork;

        [HttpGet("full")]
        public override async Task<IActionResult> GetAsync()
        {
            var action = await _unitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpGet]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _unitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}
