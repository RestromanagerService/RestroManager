using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.UnitsOfWork.interfaces
{
    public interface IProductUnitOfWork
    {
        Task<ActionResponse<Product>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<Product>>> GetAsync();
    }
}
