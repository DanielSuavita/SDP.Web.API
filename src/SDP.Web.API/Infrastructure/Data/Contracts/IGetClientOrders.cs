using SDP.Web.API.UseCases.Orders;

namespace SDP.Web.API.Infrastructure.Data.Contracts
{
    public interface IGetClientOrders
    {
        Task<List<ClientOrdersDto>> GetByClientAsync(int id);
    }
}
