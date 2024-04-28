﻿using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.UnitsOfWork.implementations;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(IGenericUnitOfWork<Category> unitOfWork, ICategoriesUnitOfWork categoriesUnitOfWork) : GenericController<Category>(unitOfWork)
    {
        private readonly ICategoriesUnitOfWork _categoriesUnitOfWork = categoriesUnitOfWork;
        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _categoriesUnitOfWork.GetTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _categoriesUnitOfWork.GetAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }



}
