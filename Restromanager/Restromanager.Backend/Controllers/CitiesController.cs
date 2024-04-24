using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.UnitsOfWork.interfaces;
using Restromanager.Backend.UnitsOfWork.Interfaces;

namespace Restromanager.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController(IGenericUnitOfWork<City> unitOfWork, ICitiesUnitOfWork citiesUnitOfWork) : GenericController<City>(unitOfWork)
    {
        private readonly ICitiesUnitOfWork _unitOfWork = citiesUnitOfWork;

        [HttpGet]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
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
    }
}
