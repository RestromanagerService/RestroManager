using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Enums;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.interfaces
{
    public interface IProductRepository
    {
        Task<ActionResponse<Product>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<Product>>> GetAsync();
        Task<ActionResponse<IEnumerable<Product>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<IEnumerable<Product>>> GetRecipesAsync();
        Task<ActionResponse<IEnumerable<Product>>> GetRecipesAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetRecipesTotalPagesAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
        Task<ActionResponse<Product>> UpdateAsync(Product entity);
        Task<ActionResponse<IEnumerable<Product>>> GetProductsByType(int id, PaginationDTO paginationDTO);
        Task<ActionResponse<int>> GetTotalProductsByTypeAsync(int id, PaginationDTO paginationDTO);
    }
}
