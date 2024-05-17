using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.Implementations;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Repositories.Interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.Interfaces;

namespace Restromanager.Backend.UnitsOfWork.implementations
{
    public class CountriesUnitOfWork(IGenericRepository<Country> repository, ICountriesRepository countriesRepository) : GenericUnitOfWork<Country>(repository), ICountriesUnitOfWork
    {
        private readonly ICountriesRepository _countriesRepository = countriesRepository;

        public override async Task<ActionResponse<Country>> GetAsync(int id) => await _countriesRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync() => await _countriesRepository.GetAsync();

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination) =>
            await _countriesRepository.GetAsync(pagination);

        public Task<ActionResponse<IEnumerable<Country>>> GetComboAsync() => _countriesRepository.GetComboAsync();

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _countriesRepository.GetTotalPagesAsync(pagination);
    }
}
