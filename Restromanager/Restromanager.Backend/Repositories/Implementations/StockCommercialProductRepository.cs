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
                .ThenInclude(p => p!.ProductCategories!)
                .ThenInclude(c=>c.Category)
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
                .ThenInclude(p => p!.ProductCategories!)
                .ThenInclude(c => c.Category)
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
                .ThenInclude(p => p!.ProductCategories!)
                .ThenInclude(c => c.Category)
                .Include(srm => srm.Units)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Product!.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<StockCommercialProduct>>
            {
                WasSuccess = true,
                Result = await queryable.Paginate(pagination).ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _dataContext.StockCommercialProducts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Product!.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            int totalPages = (int)Math.Ceiling(count / pagination.RecordsNumber);
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = totalPages
            };


        }

        public override async Task<ActionResponse<StockCommercialProduct>> UpdateAsync(StockCommercialProduct entity)
        {
            
            
            try
            {
                await _dataContext.ProductCategories.Where(p => p.ProductId == entity.ProductId).ExecuteDeleteAsync();
                _dataContext.Update(entity);
                await _dataContext.SaveChangesAsync();
                return new ActionResponse<StockCommercialProduct>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception ex)
            {
                return ExceptionActionResponse(ex);
            }
        }
        private ActionResponse<StockCommercialProduct> ExceptionActionResponse(Exception exception)
        {
            return new ActionResponse<StockCommercialProduct>
            {
                WasSuccess = false,
                Message = exception.Message
            };
        }

        private ActionResponse<StockCommercialProduct> DbUpdateExceptionActionResponse()
        {
            return new ActionResponse<StockCommercialProduct>
            {
                WasSuccess = false,
                Message = "Ya existe el registro que estas intentando crear"
            };
        }
    }

}
