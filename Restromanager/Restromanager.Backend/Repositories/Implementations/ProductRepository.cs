using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.Implementations
{
    public class ProductRepository(DataContext dataContext) :GenericRepository<Product>(dataContext),IProductRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public override async Task<ActionResponse<Product>> GetAsync(int id)
        {
            var product= await _dataContext.Products
                .Include(p=>p.ProductFoods!)
                .ThenInclude(pf=>pf.Food)
                .FirstOrDefaultAsync(p=>p.Id==id);
            if(product == null)
            {
                return new ActionResponse<Product>
                {
                    WasSuccess = false,
                    Message = "El producto no existe"
                };
            }
            return new ActionResponse<Product>
            {
                WasSuccess = true,
                Result = product
            };
        }

        public override async Task<ActionResponse<IEnumerable<Product>>> GetAsync()
        {
            var products = await _dataContext.Products
                .Include(p => p.ProductFoods!)
                .ThenInclude(pf => pf.Food)
                .ToListAsync();
            return new ActionResponse<IEnumerable<Product>>
            {
                WasSuccess = true,
                Result = products
            };
        }
    }
}
