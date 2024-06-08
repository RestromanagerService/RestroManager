using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Enums;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.Helpers
{
    public class OrdersHelper : IOrdersHelper
    {
        private readonly IUserUnitOfWork _usersUnitOfWork;
        private readonly IProductUnitOfWork _productsUnitOfWork;
        private readonly IOrderUnitOfWork _ordersUnitOfWork;
        private readonly DataContext _dataContext;

        public OrdersHelper(
            IUserUnitOfWork usersUnitOfWork,
            IProductUnitOfWork productsUnitOfWork,
            IOrderUnitOfWork ordersUnitOfWork,
            DataContext dataContext)
        {
            _usersUnitOfWork = usersUnitOfWork;
            _productsUnitOfWork = productsUnitOfWork;
            _ordersUnitOfWork = ordersUnitOfWork;
            _dataContext= dataContext;
        }
        public async Task<ActionResponse<bool>> ProcessOrderAsync(string email,int tableId, List<OrderDetail> orderDetails)
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

            if (orderDetails == null || orderDetails.Count == 0)
            {
                return new ActionResponse<bool>
                {
                    WasSuccess = false,
                    Message = "No hay detalles en la orden"
                };
            }
            var table = await _dataContext.Tables.FirstOrDefaultAsync(t=>t.Id==tableId);
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
                User = user,
                Table= table,
                OrderDetails = orderDetails,
                OrderStatus = OrderStatus.New
            };

            foreach (var orderDetail in order.OrderDetails)
            {
                var actionProduct = await _productsUnitOfWork.GetAsync(orderDetail.Product!.Id);
                if (actionProduct.WasSuccess)
                {
                    var product = actionProduct.Result;
                    if (product != null)
                    { 

                    }
                }
            }
            await _ordersUnitOfWork.AddAsync(order);
            return new ActionResponse<bool> { WasSuccess = true };
        }
    }
}