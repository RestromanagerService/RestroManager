using Microsoft.EntityFrameworkCore;
using Orders.Backend.Helpers;
using Orders.DTOs;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;
using System.Diagnostics.Metrics;

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
            return new ActionResponse<IEnumerable<StockRawMaterial>>
            {
                WasSuccess = true,
                Result = await queryable.Paginate(pagination).ToListAsync()
            };
        }


    }
}
