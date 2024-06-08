using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.UnitsOfWork.implementations;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IGenericUnitOfWork<Product> unitOfWork, IProductUnitOfWork productUnitOfWork) : GenericController<Product>(unitOfWork)
    {
        private readonly IProductUnitOfWork _unitOfWork = productUnitOfWork;

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
        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpGet("recipes")]
        public async Task<IActionResult> GetRecipesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetRecipesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpGet("recipes/totalpages")]
        public async Task<IActionResult> GetRecipesTotalPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetRecipesTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpGet("recipes/full")]
        public async Task<IActionResult> GetRecipesAsync()
        {
            var action = await _unitOfWork.GetRecipesAsync();
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
            return BadRequest(action.Message);
        }

        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpPut]
        public override async Task<IActionResult> PutAsync(Product model)
        {
            var action = await _unitOfWork.UpdateAsync(model);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("type/{id}")]
        public async Task<IActionResult> GetProductsByType(int id, [FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetProductsByType(id, pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpGet("type/{id}/totalPages")]
        public async Task<IActionResult> GetTotalProductsByType(int id, [FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetTotalProductsByTypeAsync(id, pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }
    }
}
