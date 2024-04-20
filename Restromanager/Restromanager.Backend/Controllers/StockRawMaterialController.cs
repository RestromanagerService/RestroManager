using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockRawMaterialController(IGenericUnitOfWork<StockRawMaterial> unitOfWork,IStockRawMaterialUnitOfWork stockUnitOfWork) : GenericController<StockRawMaterial>(unitOfWork)
    {
        private readonly IStockRawMaterialUnitOfWork _unitOfWork=stockUnitOfWork;

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
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
