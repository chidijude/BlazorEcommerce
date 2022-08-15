namespace BlazorEcommerce.Client.Services.OrderService;

public interface IOrderService
{
    Task PlaceOrder();
    Task<List<OrderOverViewResponse>> GetOrders();
    Task<OrderDetailsResponse> GetOrderDetails(int orderId);
}
