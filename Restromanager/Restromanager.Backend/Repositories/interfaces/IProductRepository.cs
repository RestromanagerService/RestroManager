using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.interfaces
{
    public interface IProductRepository
    {
        Task<ActionResponse<Product>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<Product>>> GetAsync();
    }
}
