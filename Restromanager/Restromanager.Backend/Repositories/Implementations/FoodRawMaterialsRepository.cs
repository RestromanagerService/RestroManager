using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.Implementations
{
    public class FoodRawMaterialsRepository(DataContext dataContext) :GenericRepository<FoodRawMaterial>(dataContext),IFoodRawMaterialsRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public override async Task<ActionResponse<FoodRawMaterial>> GetAsync(int id)
        {
            var foodRawMaterial = await _dataContext.FoodRawMaterials
                .Include(fr=>fr.RawMaterial)
                .FirstOrDefaultAsync(fr => fr.Id == id);
            if(foodRawMaterial == null)
            {
                return new ActionResponse<FoodRawMaterial>
                {
                    WasSuccess = false,
                    Message = "La materia prima no pertenece al alimento"
                };
            }
            return new ActionResponse<FoodRawMaterial>
            {
                WasSuccess = true,
                Result = foodRawMaterial
            };
        }
    }
}
