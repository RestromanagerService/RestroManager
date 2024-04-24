using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.Repositories.Interfaces;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.Implementations
{
    public class CitiesRepository(DataContext dataContext) : GenericRepository<City>(dataContext), ICitiesRepository
    {
        private readonly DataContext _context=dataContext;
        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Cities
                .Where(c=>c.StateId==pagination.Id)
                .AsQueryable();
            return new ActionResponse<IEnumerable<City>>
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
            var queryable = _context.Cities
                .Where(c=>c.StateId==pagination.Id)
                .AsQueryable();
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
