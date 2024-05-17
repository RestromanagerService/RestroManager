using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Repositories.Interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.Interfaces;

namespace Restromanager.Backend.UnitsOfWork.implementations
{
    public class FoodsUnitOfWork(IGenericRepository<Food> repository, IFoodsRepository foodsRepository) : GenericUnitOfWork<Food>(repository), IFoodsUnitOfWork 
    {
        private readonly IFoodsRepository _foodsRepository = foodsRepository;
        public override async Task<ActionResponse<Food>> GetAsync(int id) => await _foodsRepository.GetAsync(id);
        public override async Task<ActionResponse<IEnumerable<Food>>> GetAsync(PaginationDTO pagination) => await _foodsRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _foodsRepository.GetTotalPagesAsync(pagination);

    }
}
