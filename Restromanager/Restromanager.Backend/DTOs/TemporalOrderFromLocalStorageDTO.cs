using Restromanager.Backend.Enums;

namespace Restromanager.Backend.DTOs
{
    public class TemporalOrderFromLocalStorageDTO
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<TemporalOrderDTO> temporalOrders { get; set; } = new List<TemporalOrderDTO>();
    }
}
