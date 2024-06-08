using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.UnitsOfWork.implementations;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IGenericUnitOfWork<Product> unitOfWork, IProductUnitOfWork productUnitOfWork, IFileStorage fileStorage) : GenericController<Product>(unitOfWork)
    {
        private readonly IProductUnitOfWork _productUnitOfWork = productUnitOfWork;
        private readonly IGenericUnitOfWork<Product> _unitOfWork = unitOfWork;
        private readonly IFileStorage _fileStorage = fileStorage;
        private readonly string _container = "products";

        [HttpGet("full")]
        public override async Task<IActionResult> GetAsync()
        {
            var action = await _productUnitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpGet]
        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var action = await _productUnitOfWork.GetAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpGet("recipes")]
        public async Task<IActionResult> GetRecipesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _productUnitOfWork.GetRecipesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpGet("recipes/totalpages")]
        public async Task<IActionResult> GetRecipesTotalPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _productUnitOfWork.GetRecipesTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpGet("recipes/full")]
        public async Task<IActionResult> GetRecipesAsync()
        {
            var action = await _productUnitOfWork.GetRecipesAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _productUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _productUnitOfWork.GetTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpPut]
        public override async Task<IActionResult> PutAsync(Product model)
        {
            if (!string.IsNullOrEmpty(model.Photo))
            {
                if (!model.Photo.Contains(_container))
                {
                    var photoFood = Convert.FromBase64String(model.Photo);
                    model.Photo = await _fileStorage.SaveFileAsync(photoFood, ".jpg", _container);
                }
            }
            var action = await _productUnitOfWork.UpdateAsync(model);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpPost]
        public override async Task<IActionResult> PostAsync(Product model)
        {
            if (!string.IsNullOrEmpty(model.Photo))
            {
                var photoFood = Convert.FromBase64String(model.Photo);
                model.Photo = await _fileStorage.SaveFileAsync(photoFood, ".jpg", _container);
            }
            var action = await _unitOfWork.AddAsync(model);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpGet("type/{id}")]
        public async Task<IActionResult> GetProductsByType(int id, [FromQuery] PaginationDTO pagination)
        {
            var action = await _productUnitOfWork.GetProductsByType(id, pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpGet("type/{id}/totalPages")]
        public async Task<IActionResult> GetTotalProductsByType(int id, [FromQuery] PaginationDTO pagination)
        {
            var action = await _productUnitOfWork.GetTotalProductsByTypeAsync(id, pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }
    }
}
