using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.Implementations;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.UnitsOfWork.implementations
{
    public class ProductUnitOfWork(IGenericRepository<Product> genericRepository, IProductRepository productRepository) : GenericUnitOfWork<Product>(genericRepository), IProductUnitOfWork
    {
        private readonly IProductRepository _productRepository = productRepository;

        public override async Task<ActionResponse<Product>> GetAsync(int id) => await _productRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<Product>>> GetAsync() => await _productRepository.GetAsync();

        public override async Task<ActionResponse<IEnumerable<Product>>> GetAsync(PaginationDTO pagination) => await _productRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _productRepository.GetTotalPagesAsync(pagination);

        public virtual async Task<ActionResponse<IEnumerable<Product>>> GetRecipesAsync(PaginationDTO pagination) => await _productRepository.GetRecipesAsync(pagination);

        public virtual async Task<ActionResponse<IEnumerable<Product>>> GetRecipesAsync() => await _productRepository.GetRecipesAsync();
        public virtual async Task<ActionResponse<int>> GetRecipesTotalPagesAsync(PaginationDTO pagination) => await _productRepository.GetRecipesTotalPagesAsync(pagination);
        public override async Task<ActionResponse<Product>> UpdateAsync(Product model) => await _productRepository.UpdateAsync(model);
        public virtual async Task<ActionResponse<IEnumerable<Product>>> GetProductsByType(int id, PaginationDTO paginationDTO)
        {
            return await _productRepository.GetProductsByType(id, paginationDTO);
        }

        public virtual async Task<ActionResponse<int>> GetTotalProductsByTypeAsync(int id, PaginationDTO paginationDTO)
        {
            return await _productRepository.GetTotalProductsByTypeAsync(id, paginationDTO);
        }
    }

}
