
namespace Ecommerce.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Users> ListUsers { get; set; }
        public Users User { get; set; }
        public List<Medicines> ListMedicines { get; set; }
        public Medicines Medicine { get; set; }
        public List<Cart> ListCart { get; set; }
        public List<Orders> ListOrders { get; set; }
        public Orders Order { get; set; }
        public List<OrderItems> ListOrderItems { get; set; }
        public OrderItems OrderItem { get; set; }
    }
}