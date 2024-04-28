using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.interfaces
{
    public interface IStockRawMaterialRepository
    {
        Task<ActionResponse<StockRawMaterial>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<StockRawMaterial>>> GetAsync();

        Task<ActionResponse<IEnumerable<StockRawMaterial>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}
