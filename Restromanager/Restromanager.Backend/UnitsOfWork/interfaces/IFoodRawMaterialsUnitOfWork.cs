using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.UnitsOfWork.interfaces
{
    public interface IFoodRawMaterialsUnitOfWork
    {
        Task<ActionResponse<FoodRawMaterial>> GetAsync(int id);
    }
}
