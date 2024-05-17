using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Repositories.Interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.Interfaces;

namespace Restromanager.Backend.UnitsOfWork.implementations
{
    public class StatesUnitOfWork(IGenericRepository<State> repository, IStatesRepository statesRepository) : GenericUnitOfWork<State>(repository), IStatesUnitOfWork
    {
        private readonly IStatesRepository _statesRepository = statesRepository;

        public override async Task<ActionResponse<State>> GetAsync(int id) => await _statesRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync() => await _statesRepository.GetAsync();
        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination) => await _statesRepository.GetAsync(pagination);

        public Task<ActionResponse<IEnumerable<State>>> GetComboAsync(int countryId) => _statesRepository.GetComboAsync(countryId);

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _statesRepository.GetTotalPagesAsync(pagination);


    }
}
