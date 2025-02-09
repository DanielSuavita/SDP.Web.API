using FluentResults;
using SDP.Web.API.Infrastructure.Data.Queries;
using SDP.Web.API.UseCases.Customers;

namespace SDP.Web.API.UseCases.Products.GetAll
{
    public class GetAllProductsHandler : IQueryHandler<GetProductsQuery, Result<List<ProductsDTO>>>
    {
        public async Task<Result<List<ProductsDTO>>> Handle(GetProductsQuery query)
        {
            List<ProductsDTO> Products = await query.GetAllAsync();

            if (Products == null)
            {
                return new Error("No hay Productos");
            }

            return Result.Ok(Products);
        }
    }
}
