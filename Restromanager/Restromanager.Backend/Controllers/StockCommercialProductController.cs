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
    public class StockCommercialProductController(IGenericUnitOfWork<StockCommercialProduct> unitOfWork, IStockCommercialProductUnitOfWork stockUnitOfWork, IFileStorage fileStorage) : GenericController<StockCommercialProduct>(unitOfWork)
    {
        private readonly IStockCommercialProductUnitOfWork _stockUnitOfWork = stockUnitOfWork;
        private readonly IGenericUnitOfWork<StockCommercialProduct> _unitOfWork = unitOfWork;
        private readonly IFileStorage _fileStorage = fileStorage;
        private readonly string _container = "products";

        [HttpGet("full")]
        public override async Task<IActionResult> GetAsync()
        {
            var action = await _stockUnitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpGet]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _stockUnitOfWork.GetAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _stockUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpPut]
        public override async Task<IActionResult> PutAsync(StockCommercialProduct model)
        {
            if (!string.IsNullOrEmpty(model.Product?.Photo))
            {
                if (!model.Product.Photo.Contains(_container))
                {
                    var photoFood = Convert.FromBase64String(model.Product.Photo!);
                    model.Product.Photo = await _fileStorage.SaveFileAsync(photoFood, ".jpg", _container);
                }
            }
            var action = await _stockUnitOfWork.UpdateAsync(model);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpPost]
        public override async Task<IActionResult> PostAsync(StockCommercialProduct model)
        {
            if (!string.IsNullOrEmpty(model.Product!.Photo))
            {
                var photoFood = Convert.FromBase64String(model.Product.Photo);
                model.Product.Photo = await _fileStorage.SaveFileAsync(photoFood, ".jpg", _container);
            }
            var action = await _unitOfWork.AddAsync(model);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _stockUnitOfWork.GetTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}
