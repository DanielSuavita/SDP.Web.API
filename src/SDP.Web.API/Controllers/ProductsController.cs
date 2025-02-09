using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDP.Web.API.Infrastructure.Data;
using SDP.Web.API.Infrastructure.Data.Queries;
using SDP.Web.API.UseCases.Customers;
using SDP.Web.API.UseCases.Products;
using SDP.Web.API.UseCases.Products.GetAll;

namespace SDP.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GetAllProductsHandler QueryHandler = new();
        private readonly WebAppDBContext DbContext;

        public ProductsController(WebAppDBContext _DbContext)
        {
            DbContext = _DbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Result<List<ProductsDTO>> Response = await QueryHandler.Handle(new GetProductsQuery(DbContext));

            if (Response.Errors.Count > 0)
            {
                return BadRequest(Response.Errors);
            }

            return Ok(Response.Value);
        }
    }
}
