using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.UnitsOfWork.implementations;
using Restromanager.Backend.UnitsOfWork.interfaces;
using Restromanager.Backend.UnitsOfWork.Interfaces;

namespace Restromanager.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController(IGenericUnitOfWork<Food> unitOfWork, IFileStorage fileStorage, IFoodsUnitOfWork foodsUnitOfWork) : GenericController<Food>(unitOfWork)
    {
        private readonly IGenericUnitOfWork<Food> _unitOfWork = unitOfWork;
        private readonly IFoodsUnitOfWork _foodsUnitOfWork = foodsUnitOfWork;
        private readonly IFileStorage _fileStorage = fileStorage;
        private readonly string _container = "foods";

        [HttpPut]
        public override async Task<IActionResult> PutAsync(Food model)
        {
            if (!string.IsNullOrEmpty(model.Photo))
            {
                if (!model.Photo.Contains(_container))
                {
                    var photoFood = Convert.FromBase64String(model.Photo!);
                    model.Photo = await _fileStorage.SaveFileAsync(photoFood, ".jpg", _container);
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
        public override async Task<IActionResult> PostAsync(Food model)
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



        [HttpGet]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _foodsUnitOfWork.GetAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _foodsUnitOfWork.GetTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _foodsUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

    }
}
