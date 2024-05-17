using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.interfaces
{
    public interface IFoodRawMaterialsRepository
    {
        Task<ActionResponse<FoodRawMaterial>> GetAsync(int id);
    }
}
