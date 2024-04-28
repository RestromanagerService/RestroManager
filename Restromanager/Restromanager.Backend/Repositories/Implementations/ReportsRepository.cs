﻿using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.Implementations
{
    public class ReportsRepository : GenericRepository<Report>, IReportsRepository
    {
        private readonly DataContext _context;

        public ReportsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<Report>> GetAsync(int id)
        {
            var report = await _context.Reports
                .Include(x => x.UserReport)
                .Include(y => y.TypeReport)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (report == null)
            {
                return new ActionResponse<Report>
                {
                    WasSuccess = false,
                    Message = "El reporte no existe"
                };
            }
            return new ActionResponse<Report>
            {
                WasSuccess = true,
                Result = report
            };
        }

        public override async Task<ActionResponse<IEnumerable<Report>>> GetAsync()
        {
            var reports = await _context.Reports
                .Include(x => x.UserReport)
                .Include(y => y.TypeReport)
                .ToListAsync();
            return new ActionResponse<IEnumerable<Report>>
            {
                WasSuccess = true,
                Result = reports
            };
        }

        public async Task<ActionResponse<IEnumerable<Report>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Reports.Include(x => x.UserReport).Include(y => y.TypeReport).AsQueryable();
            return new ActionResponse<IEnumerable<Report>>
            {
                WasSuccess = true,
                Result = await queryable
                .OrderBy(r => r.Name)
                .Paginate(pagination)
                .ToListAsync()
            };
        }



    }
}
