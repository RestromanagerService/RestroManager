using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.Implementations
{
    public class StockRawMaterialRepository(DataContext dataContext) :GenericRepository<StockRawMaterial>(dataContext),IStockRawMaterialRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public override async Task<ActionResponse<StockRawMaterial>> GetAsync(int id)
        {
            var stockRawMaterial=await _dataContext.StockRawMaterials
                .Include(srm=>srm.RawMaterial)
                .Include(srm=>srm.Units)
                .FirstOrDefaultAsync(srm => srm.Id == id);
            if(stockRawMaterial == null)
            {
                return new ActionResponse<StockRawMaterial>
                {
                    WasSuccess = false,
                    Message = "No hay stock disponible"
                };
            }
            return new ActionResponse<StockRawMaterial>
            {
                WasSuccess = true,
                Result = stockRawMaterial
            };
        }

        public override async Task<ActionResponse<IEnumerable<StockRawMaterial>>> GetAsync()
        {
            var stockRawMaterials = await _dataContext.StockRawMaterials
                .Include(srm => srm.RawMaterial)
                .Include(srm => srm.Units)
                .ToListAsync();
            return new ActionResponse<IEnumerable<StockRawMaterial>>
            {
                WasSuccess = true,
                Result = stockRawMaterials
            };
        }

        public override async Task<ActionResponse<IEnumerable<StockRawMaterial>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _dataContext.StockRawMaterials
                .Include(srm => srm.RawMaterial)
                .Include(srm => srm.Units)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.RawMaterial!.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<StockRawMaterial>>
            {
                WasSuccess = true,
                Result = await queryable.Paginate(pagination).ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _dataContext.StockRawMaterials.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.RawMaterial!.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            int totalPages = (int)Math.Ceiling(count / pagination.RecordsNumber);
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = totalPages
            };


        }


    }
}
