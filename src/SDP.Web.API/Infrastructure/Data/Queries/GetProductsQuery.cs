using FluentResults;
using Microsoft.EntityFrameworkCore;
using SDP.Web.API.Infrastructure.Data.Contracts;
using SDP.Web.API.UseCases.Products;
using SDP.Web.API.UseCases.Shippers;

namespace SDP.Web.API.Infrastructure.Data.Queries
{
    public class GetProductsQuery(WebAppDBContext DbContext) : IGetProducts
    {
        public async Task<List<ProductsDTO>> GetAllAsync()
        {
            IQueryable<ProductsDTO> Query = DbContext.Database.SqlQuery<ProductsDTO>($"SELECT productid, productname FROM [Production].[GetProducts]");
            List<ProductsDTO> Data = await Query.ToListAsync();
            return Data;
        }
    }
}
