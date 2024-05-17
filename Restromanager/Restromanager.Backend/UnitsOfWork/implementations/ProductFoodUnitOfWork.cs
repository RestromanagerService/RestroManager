using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.Implementations;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.UnitsOfWork.implementations
{
    public class ProductFoodUnitOfWork(IGenericRepository<ProductFood> genericRepository, IProductFoodRepository productFoodRepository): GenericUnitOfWork<ProductFood>(genericRepository), IProductFoodUnitOfWork
    {
        private readonly IProductFoodRepository _productFoodRepository=productFoodRepository;

        public override async Task<ActionResponse<ProductFood>> GetAsync(int id)=> await _productFoodRepository.GetAsync(id);
    }

}
