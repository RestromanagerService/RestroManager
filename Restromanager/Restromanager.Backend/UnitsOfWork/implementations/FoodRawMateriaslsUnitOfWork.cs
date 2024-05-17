using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.Implementations;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.UnitsOfWork.implementations
{
    public class FoodRawMateriaslsUnitOfWork(IGenericRepository<FoodRawMaterial> genericRepository, IFoodRawMaterialsRepository foodRawMaterialsRepository): GenericUnitOfWork<FoodRawMaterial>(genericRepository), IFoodRawMaterialsUnitOfWork
    {
        private readonly IFoodRawMaterialsRepository _foodRawMaterialsRepository = foodRawMaterialsRepository;

        public override async Task<ActionResponse<FoodRawMaterial>> GetAsync(int id)=> await _foodRawMaterialsRepository.GetAsync(id);
    }

}
