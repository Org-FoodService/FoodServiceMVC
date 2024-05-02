using FoodService.Data.Model.Auth.User;

namespace FoodService.Data.Model
{
    public class Order
    {
        public required int OrderId { get; set; }
        public required List<OrderItem> OrderItens { get; set; }
        public required ApplicationUser User { get; set; }
    }

    public class OrderItem
    {
        public required int OrderItemId { get; set; }
        public required int Quantidade { get; set; }
        public string? Comentario { get; set; }

        public required int OrderId { get; set; }
        public required Product Product { get; set; }
    }
}
