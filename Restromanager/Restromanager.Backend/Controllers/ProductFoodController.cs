using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductFoodController(IGenericUnitOfWork<ProductFood> unitOfWork, IProductFoodUnitOfWork productFoodUnitOfWork, IFileStorage fileStorage) : GenericController<ProductFood>(unitOfWork)
    {
        private readonly IProductFoodUnitOfWork _productFoodUnitOfWork = productFoodUnitOfWork;
        private readonly IGenericUnitOfWork<ProductFood> _unitOfWork = unitOfWork;
        private readonly IFileStorage _fileStorage = fileStorage;
        private readonly string _container = "foods";

        [HttpPut]
        public override async Task<IActionResult> PutAsync(ProductFood model)
        {
            if (!string.IsNullOrEmpty(model.Food?.Photo))
            {
                if (!model.Food.Photo.Contains(_container))
                {
                    var photoFood = Convert.FromBase64String(model.Food.Photo!);
                    model.Food.Photo = await _fileStorage.SaveFileAsync(photoFood, ".jpg", _container);
                }
            }
            var action = await _unitOfWork.UpdateAsync(model);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpPost]
        public override async Task<IActionResult> PostAsync(ProductFood model)
        {
            if (!string.IsNullOrEmpty(model.Food?.Photo))
            {
                var photoFood = Convert.FromBase64String(model.Food.Photo!);
                model.Food.Photo = await _fileStorage.SaveFileAsync(photoFood, ".jpg", _container);
            }
            var action = await _unitOfWork.AddAsync(model);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _productFoodUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }



    }
}
