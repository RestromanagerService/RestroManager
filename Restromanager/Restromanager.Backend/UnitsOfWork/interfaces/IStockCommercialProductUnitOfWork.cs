using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.UnitsOfWork.interfaces
{
    public interface IStockCommercialProductUnitOfWork
    {
        Task<ActionResponse<StockCommercialProduct>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<StockCommercialProduct>>> GetAsync();
        Task<ActionResponse<IEnumerable<StockCommercialProduct>>> GetAsync(PaginationDTO pagination);
    }
}
