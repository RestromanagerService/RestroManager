using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.Implementations
{
    public class ReportsRepository : GenericRepository<Report>, IReportsRepository
    {
        private readonly DataContext _dataContext;

        public ReportsRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }

        public async Task<ActionResponse<Report>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
        // venecos


    }
}
