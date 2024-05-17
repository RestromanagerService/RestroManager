using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.Repositories.Interfaces;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.Implementations
{
    public class FoodsRepository(DataContext dataContext) : GenericRepository<Food>(dataContext), IFoodsRepository
    {
        private readonly DataContext _context=dataContext;
        public override async Task<ActionResponse<IEnumerable<Food>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Foods
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }


            return new ActionResponse<IEnumerable<Food>>
            {
                WasSuccess = true,
                Result = await queryable
                .OrderBy(c => c.Name)
                .Paginate(pagination)
                .ToListAsync()
            };
        }
        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _context.Foods
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            int totalPages = (int)Math.Ceiling(count / pagination.RecordsNumber);
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = totalPages
            };
        }
        public override async Task<ActionResponse<Food>> GetAsync(int id)
        {
            var food = await _context.Foods
                .Include(f => f.FoodRawMaterials!)
                .ThenInclude(fr => fr.RawMaterial)
                .Include(f => f.FoodRawMaterials!)
                .ThenInclude(fr => fr.Units)
                .FirstOrDefaultAsync(f => f.Id == id);
            if (food == null)
            {
                return new ActionResponse<Food>
                {
                    WasSuccess = false,
                    Message = "Alimento no existe"
                };
            }
            return new ActionResponse<Food>
            {
                WasSuccess = true,
                Result = food
            };

        }
    }
}
