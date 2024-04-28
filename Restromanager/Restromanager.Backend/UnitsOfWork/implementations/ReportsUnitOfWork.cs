using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.UnitsOfWork.implementations
{
    public class ReportsUnitOfWork(IGenericRepository<Report> repository, IReportsRepository reportsRepository) : GenericUnitOfWork<Report>(repository), IReportsUnitOfWork
    {
        private readonly IReportsRepository _reportsRepository = reportsRepository;

        public override async Task<ActionResponse<Report>> GetAsync(int id) => await _reportsRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<Report>>> GetAsync() => await _reportsRepository.GetAsync();

        public override async Task<ActionResponse<IEnumerable<Report>>> GetAsync(PaginationDTO pagination) =>
            await _reportsRepository.GetAsync(pagination);
        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _reportsRepository.GetTotalPagesAsync(pagination);



    }
}
