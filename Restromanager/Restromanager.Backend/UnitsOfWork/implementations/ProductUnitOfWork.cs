using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.UnitsOfWork.implementations
{
    public class ProductUnitOfWork(IGenericRepository<Product> genericRepository, IProductRepository productRepository): GenericUnitOfWork<Product>(genericRepository), IProductUnitOfWork
    {
        private readonly IProductRepository _productRepository=productRepository;

        public override async Task<ActionResponse<Product>> GetAsync(int id)=> await _productRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<Product>>> GetAsync() => await _productRepository.GetAsync();
    }

}
