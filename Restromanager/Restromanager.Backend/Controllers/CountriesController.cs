using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.UnitsOfWork.implementations;
using Restromanager.Backend.UnitsOfWork.interfaces;
using Restromanager.Backend.UnitsOfWork.Interfaces;

namespace Restromanager.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController(IGenericUnitOfWork<Country> unitOfWork, ICountriesUnitOfWork countriesUnitOfWork) : GenericController<Country>(unitOfWork)
    {
        private readonly ICountriesUnitOfWork _countriesUnitOfWork = countriesUnitOfWork;

        [HttpGet("full")]
        public override async Task<IActionResult> GetAsync()
        {
            var action = await _countriesUnitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpGet]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _countriesUnitOfWork.GetAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _countriesUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _countriesUnitOfWork.GetTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
        [HttpGet("combo")]
        public async Task<IActionResult> GetComboAsync()
        {
            var action = await _countriesUnitOfWork.GetComboAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}
