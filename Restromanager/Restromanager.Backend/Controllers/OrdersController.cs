using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Enums;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restrommanager.Backend.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersHelper _ordersHelper;
        private readonly IOrderUnitOfWork _ordersUnitOfWork;

        public OrdersController(IOrdersHelper ordersHelper, IOrderUnitOfWork ordersUnitOfWork)
        {
            _ordersHelper = ordersHelper;
            _ordersUnitOfWork = ordersUnitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var response = await _ordersUnitOfWork.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _ordersUnitOfWork.GetAsync(User.Identity!.Name!, pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("totalPages")]
        public async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _ordersUnitOfWork.GetTotalPagesAsync(User.Identity!.Name!, pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(OrderDTO orderDTO)
        {
            var response = await _ordersHelper.ProcessOrderAsync(User.Identity!.Name!,orderDTO.TableId);
            if (response.WasSuccess)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> PatchStatusAsync(int id, [FromBody] OrderDTO orderDTO)
        {
            var response = await _ordersUnitOfWork.GetAsync(id);
            if (!response.WasSuccess)
            {
                return NotFound(response.Message);
            }

            var order = response.Result;
            order.OrderStatus = orderDTO.OrderStatus;

            var updateResponse = await _ordersUnitOfWork.UpdateAsync(order);
            if (updateResponse.WasSuccess)
            {
                return Ok(updateResponse.Result);
            }
            return BadRequest(updateResponse.Message);
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetByStatusAsync([FromQuery] String status)
        {
            var response = await _ordersUnitOfWork.GetByStatusAsync(status);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }
    }
}