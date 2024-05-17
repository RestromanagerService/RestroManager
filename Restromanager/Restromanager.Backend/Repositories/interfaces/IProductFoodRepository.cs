using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.interfaces
{
    public interface IProductFoodRepository
    {
        Task<ActionResponse<ProductFood>> GetAsync(int id);
    }
}
