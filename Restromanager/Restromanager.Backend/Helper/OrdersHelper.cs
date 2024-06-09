using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Enums;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;
using Restromanager.Backend.DTOs;

namespace Restromanager.Backend.Helpers
{
    public class OrdersHelper : IOrdersHelper
    {
        private readonly IUserUnitOfWork _usersUnitOfWork;
        private readonly ITemporalOrdersUnitOfWork _temporalOrdersUnitOfWork;
        private readonly IProductUnitOfWork _productsUnitOfWork;
        private readonly IOrderUnitOfWork _ordersUnitOfWork;
        private readonly DataContext _dataContext;

        public OrdersHelper(
            IUserUnitOfWork usersUnitOfWork,
            ITemporalOrdersUnitOfWork temporalOrdersUnitOfWork,
            IProductUnitOfWork productsUnitOfWork,
            IOrderUnitOfWork ordersUnitOfWork,
            DataContext dataContext)
        {
            _usersUnitOfWork = usersUnitOfWork;
            _productsUnitOfWork = productsUnitOfWork;
            _temporalOrdersUnitOfWork = temporalOrdersUnitOfWork;
            _ordersUnitOfWork = ordersUnitOfWork;
            _dataContext = dataContext;
        }

        public async Task<ActionResponse<bool>> ProcessOrderAnAsync(IEnumerable<TemporalOrderDTO> temporalOrders, int tableId)
        {
            var table = await _dataContext.Tables.FirstOrDefaultAsync(t => t.Id == tableId);
            if (table == null)
            {
                return new ActionResponse<bool>
                {
                    WasSuccess = false,
                    Message = "La mesa no existe"
                };
            }

            var order = new Order
            {
                Date = DateTime.UtcNow,
                Table = table,
                OrderStatus = OrderStatus.New,
                OrderDetails = new List<OrderDetail>()
            };
            if (!temporalOrders.Any())
            {
                return new ActionResponse<bool>
                {
                    WasSuccess = false,
                    Message = "No hay productos en la orden"
                };
            }

            foreach (var temporalOrder in temporalOrders)
            {
                var productInOrderDetail = _productsUnitOfWork.GetAsync(temporalOrder.ProductId).Result.Result;
                var orderDetail = new OrderDetail
                {
                    Product = productInOrderDetail,
                    ProductId = temporalOrder.ProductId,
                    Quantity = temporalOrder.Quantity,
                    Order = order
                };

                order.OrderDetails.Add(orderDetail);
            }

            await _ordersUnitOfWork.AddAsync(order);

            return new ActionResponse<bool>
            {
                WasSuccess = true,
                Message = order.Id.ToString()
            };
        }
        public async Task<ActionResponse<bool>> ProcessOrderAsync(string email, int tableId)
        {
            var user = await _usersUnitOfWork.GetUserAsync(email);
            if (user == null)
            {
                return new ActionResponse<bool>
                {
                    WasSuccess = false,
                    Message = "Usuario no válido"
                };
            }

            var table = await _dataContext.Tables.FirstOrDefaultAsync(t => t.Id == tableId);
            if (table == null)
            {
                return new ActionResponse<bool>
                {
                    WasSuccess = false,
                    Message = "La mesa no existe"
                };
            }

            var actionTemporalOrders = await _temporalOrdersUnitOfWork.GetAsync(email);
            if (!actionTemporalOrders.WasSuccess)
            {
                return new ActionResponse<bool>
                {
                    WasSuccess = false,
                    Message = "No hay orden temporal disponible."
                };
            }
            var temporalOrders = actionTemporalOrders.Result as List<TemporalOrder>;
            if (temporalOrders.Count == 0) 
            {
                return new ActionResponse<bool>
                {
                    WasSuccess = false,
                    Message = "No hay orden temporal disponible."
                };
            }
            
            var order = new Order
            {
                Date = DateTime.UtcNow,
                User = user,
                Table = table,
                OrderStatus = OrderStatus.New,
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var temporalOrder in temporalOrders)
            {
                var orderDetail = new OrderDetail
                {
                    Product = temporalOrder.Product,
                    ProductId = temporalOrder.ProductId,
                    Quantity = temporalOrder.Quantity,
                    Value = temporalOrder.Value,
                    Order = order
                };

                order.OrderDetails.Add(orderDetail);
            }
            await _ordersUnitOfWork.AddAsync(order);
            foreach (var temporalOrder in temporalOrders)
            {
                _dataContext.TemporalOrders.Remove(temporalOrder);
            }
            await _dataContext.SaveChangesAsync();
            return new ActionResponse<bool>
            {
                WasSuccess = true,
                Message = order.Id.ToString()
            };
        }
    }
}