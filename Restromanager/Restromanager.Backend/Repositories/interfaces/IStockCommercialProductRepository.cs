using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.interfaces
{
    public interface IStockCommercialProductRepository
    {
        Task<ActionResponse<StockCommercialProduct>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<StockCommercialProduct>>> GetAsync();
        Task<ActionResponse<IEnumerable<StockCommercialProduct>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<StockCommercialProduct>> UpdateAsync(StockCommercialProduct entity);
    }
}
