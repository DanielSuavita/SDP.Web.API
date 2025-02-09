using SDP.Web.API.UseCases.Shippers;

namespace SDP.Web.API.Infrastructure.Data.Contracts
{
    public interface IGetShippers
    {
        Task<List<ShippersDTO>> GetAllAsync();
    }
}
