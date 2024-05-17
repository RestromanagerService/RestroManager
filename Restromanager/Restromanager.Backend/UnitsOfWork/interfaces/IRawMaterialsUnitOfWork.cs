using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.UnitsOfWork.Interfaces
{
    public interface IRawMaterialsUnitOfWork
    {
        Task<ActionResponse<IEnumerable<RawMaterial>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}
