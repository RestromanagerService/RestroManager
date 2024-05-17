using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Repositories.Interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.Interfaces;

namespace Restromanager.Backend.UnitsOfWork.implementations
{
    public class CitiesUnitOfWork(IGenericRepository<City> repository, ICitiesRepository citiesRepository) : GenericUnitOfWork<City>(repository), ICitiesUnitOfWork
    {
        private readonly ICitiesRepository _citiesRepository = citiesRepository;
        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination) => await _citiesRepository.GetAsync(pagination);

        public Task<ActionResponse<IEnumerable<City>>> GetComboAsync(int stateId) => _citiesRepository.GetComboAsync(stateId);

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _citiesRepository.GetTotalPagesAsync(pagination);

    }
}
