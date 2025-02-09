using SDP.Web.API.UseCases.Products;
using SDP.Web.API.UseCases.Shippers;

namespace SDP.Web.API.Infrastructure.Data.Contracts
{
    public interface IGetProducts
    {
        Task<List<ProductsDTO>> GetAllAsync();
    }
}
