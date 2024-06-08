using Restromanager.Backend.Enums;

namespace Restromanager.Backend.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
    }
}
