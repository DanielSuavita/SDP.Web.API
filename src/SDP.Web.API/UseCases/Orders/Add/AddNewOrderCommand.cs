namespace SDP.Web.API.UseCases.Orders.Add
{
    public record AddNewOrderCommand
    (
        NewOrderDto NewOrder,
        NewOrderDetailDto NewOrderDetail
    );
}
