using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.Implementations
{
    public class StockCommercialProductRepository(DataContext dataContext) :GenericRepository<StockCommercialProduct>(dataContext),IStockCommercialProductRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public override async Task<ActionResponse<StockCommercialProduct>> GetAsync(int id)
        {
            var stockCommercialProduct=await _dataContext.StockCommercialProducts
                .Include(srm=>srm.Product)
                .Include(srm=>srm.Units)
                .FirstOrDefaultAsync(srm => srm.Id == id);
            if(stockCommercialProduct == null)
            {
                return new ActionResponse<StockCommercialProduct>
                {
                    WasSuccess = false,
                    Message = "No hay stock disponible"
                };
            }
            return new ActionResponse<StockCommercialProduct>
            {
                WasSuccess = true,
                Result = stockCommercialProduct
            };
        }

        public override async Task<ActionResponse<IEnumerable<StockCommercialProduct>>> GetAsync()
        {
            var stockCommercialProducts = await _dataContext.StockCommercialProducts
                .Include(srm => srm.Product)
                .Include(srm => srm.Units)
                .ToListAsync();
            return new ActionResponse<IEnumerable<StockCommercialProduct>>
            {
                WasSuccess = true,
                Result = stockCommercialProducts
            };
        }
        public override async Task<ActionResponse<IEnumerable<StockCommercialProduct>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _dataContext.StockCommercialProducts
                .Include(srm => srm.Product)
                .Include(srm => srm.Units)
                .AsQueryable();
            return new ActionResponse<IEnumerable<StockCommercialProduct>>
            {
                WasSuccess = true,
                Result = await queryable.Paginate(pagination).ToListAsync()
        };
    }
}
}
