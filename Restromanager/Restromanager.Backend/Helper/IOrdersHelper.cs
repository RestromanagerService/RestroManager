using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Helpers
{
    public interface IOrdersHelper
    {
        Task<ActionResponse<bool>> ProcessOrderAsync(string email,int tableId);

        Task<ActionResponse<bool>> ProcessOrderAnAsync(IEnumerable<TemporalOrderDTO> temporalOrders, int tableId);
    }
}
