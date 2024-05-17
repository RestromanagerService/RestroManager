using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.UnitsOfWork.interfaces
{
    public interface IProductFoodUnitOfWork
    {
        Task<ActionResponse<ProductFood>> GetAsync(int id);
    }
}
