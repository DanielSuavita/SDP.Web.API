using SDP.Web.API.UseCases.Orders;

namespace SDP.Web.API.Infrastructure.Data.Contracts
{
    public interface IAddNewOrder
    {
        Task<bool> Create(NewOrderDto NewOrder, NewOrderDetailDto NewOrderDetail);
    }
}
