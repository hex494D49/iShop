using Microsoft.AspNetCore.SignalR;

namespace iShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        public DateTime LastModified { get; set; } = DateTime.Now;

        public int Status { get; set; }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
