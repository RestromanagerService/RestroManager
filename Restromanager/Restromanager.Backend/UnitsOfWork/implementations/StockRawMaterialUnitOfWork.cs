using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.UnitsOfWork.implementations
{
    public class StockRawMaterialUnitOfWork(IGenericRepository<StockRawMaterial> genericRepository, IStockRawMaterialRepository stockRawMaterialRepository): GenericUnitOfWork<StockRawMaterial>(genericRepository), IStockRawMaterialUnitOfWork
    {
        private readonly IStockRawMaterialRepository _stockRawMaterialRepository=stockRawMaterialRepository;

        public override async Task<ActionResponse<StockRawMaterial>> GetAsync(int id)=> await _stockRawMaterialRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<StockRawMaterial>>> GetAsync() => await _stockRawMaterialRepository.GetAsync();

        public override async Task<ActionResponse<IEnumerable<StockRawMaterial>>> GetAsync(PaginationDTO pagination) => await _stockRawMaterialRepository.GetAsync(pagination);
    }

}
