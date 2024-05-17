using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.UnitsOfWork.implementations;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodRawMaterialController(IGenericUnitOfWork<FoodRawMaterial> unitOfWork, IFoodRawMaterialsUnitOfWork foodRawMaterialsUnitOfWork, IFileStorage fileStorage) : GenericController<FoodRawMaterial>(unitOfWork)
    {
        private readonly IFoodRawMaterialsUnitOfWork _foodRawMaterialsUnitOfWork = foodRawMaterialsUnitOfWork;
        private readonly IGenericUnitOfWork<FoodRawMaterial> _unitOfWork = unitOfWork;
        private readonly IFileStorage _fileStorage = fileStorage;
        private readonly string _container = "rawMaterials";

        [HttpPut]
        public override async Task<IActionResult> PutAsync(FoodRawMaterial model)
        {
            if (!string.IsNullOrEmpty(model.RawMaterial?.Photo))
            {
                if (!model.RawMaterial.Photo.Contains(_container))
                {
                    var photoRawMaterial = Convert.FromBase64String(model.RawMaterial.Photo!);
                    model.RawMaterial.Photo = await _fileStorage.SaveFileAsync(photoRawMaterial, ".jpg", _container);
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
        public override async Task<IActionResult> PostAsync(FoodRawMaterial model)
        {
            if (!string.IsNullOrEmpty(model.RawMaterial?.Photo))
            {
                var photoRawMaterial = Convert.FromBase64String(model.RawMaterial.Photo!);
                model.RawMaterial.Photo = await _fileStorage.SaveFileAsync(photoRawMaterial, ".jpg", _container);
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
            var action = await _foodRawMaterialsUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}
