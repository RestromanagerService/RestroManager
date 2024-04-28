using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.UnitsOfWork.interfaces
{
    public interface IReportsUnitOfWork
    {
        Task<ActionResponse<Report>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<Report>>> GetAsync(); 

        Task<ActionResponse<IEnumerable<Report>>> GetAsync(PaginationDTO pagination);

    }
}
