using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class FavoriteTaste
    {
    

        public int Id { get; set; }
        public string UserID { get; set; }
        public User? User { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; }
    }
}
