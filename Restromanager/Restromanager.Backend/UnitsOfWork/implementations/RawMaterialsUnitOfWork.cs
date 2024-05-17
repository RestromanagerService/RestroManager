using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Repositories.Interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.Interfaces;

namespace Restromanager.Backend.UnitsOfWork.implementations
{
    public class RawMaterialsUnitOfWork(IGenericRepository<RawMaterial> repository, IRawMaterialsRepository rawMaterialsRepository) : GenericUnitOfWork<RawMaterial>(repository), IRawMaterialsUnitOfWork 
    {
        private readonly IRawMaterialsRepository _rawMaterialsRepository = rawMaterialsRepository;
        public override async Task<ActionResponse<IEnumerable<RawMaterial>>> GetAsync(PaginationDTO pagination) => await _rawMaterialsRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _rawMaterialsRepository.GetTotalPagesAsync(pagination);

    }
}
