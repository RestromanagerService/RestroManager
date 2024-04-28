using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.UnitsOfWork.implementations
{
    public class StockCommercialProductUnitOfWork(IGenericRepository<StockCommercialProduct> genericRepository, IStockCommercialProductRepository stockCommercialProductRepository): GenericUnitOfWork<StockCommercialProduct>(genericRepository), IStockCommercialProductUnitOfWork
    {
        private readonly IStockCommercialProductRepository _stockCommercialProductRepository=stockCommercialProductRepository;

        public override async Task<ActionResponse<StockCommercialProduct>> GetAsync(int id)=> await _stockCommercialProductRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<StockCommercialProduct>>> GetAsync() => await _stockCommercialProductRepository.GetAsync();

        public override async Task<ActionResponse<IEnumerable<StockCommercialProduct>>> GetAsync(PaginationDTO pagination) => await _stockCommercialProductRepository.GetAsync(pagination);
        public override async Task<ActionResponse<StockCommercialProduct>> UpdateAsync(StockCommercialProduct model) => await _stockCommercialProductRepository.UpdateAsync(model);
    }

}
