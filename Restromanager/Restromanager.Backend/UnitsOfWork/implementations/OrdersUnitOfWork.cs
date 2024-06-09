using Azure;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Enums;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.UnitsOfWork.implementations
{
    public class OrdersUnitOfWork : GenericUnitOfWork<Order>, IOrderUnitOfWork
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrdersUnitOfWork(IGenericRepository<Order> repository, IOrdersRepository ordersRepository) : base(repository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<ActionResponse<IEnumerable<Order>>> GetAsync(string email, PaginationDTO pagination) => await _ordersRepository.GetAsync(email, pagination);

        public async Task<ActionResponse<int>> GetTotalPagesAsync(string email, PaginationDTO pagination) => await _ordersRepository.GetTotalPagesAsync(email, pagination);

        public override async Task<ActionResponse<Order>> GetAsync(int id) => await _ordersRepository.GetAsync(id);

        public async Task<ActionResponse<Order>> UpdateAsync(Order order) => await _ordersRepository.UpdateAsync(order);

        public async Task<ActionResponse<IEnumerable<Order>>> GetByStatusAsync(String status)
        {
            return await _ordersRepository.GetByStatusAsync(status);
        }
    }
}
