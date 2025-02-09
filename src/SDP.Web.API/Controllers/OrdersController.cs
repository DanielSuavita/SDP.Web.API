using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDP.Web.API.Infrastructure.Data;
using SDP.Web.API.Infrastructure.Data.Queries;
using SDP.Web.API.Infrastructure.Data.StoredProcedures;
using SDP.Web.API.UseCases.Orders;
using SDP.Web.API.UseCases.Orders.Add;
using SDP.Web.API.UseCases.Orders.View;

namespace SDP.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ViewClientOrdersHandler ViewClientOrdersQueryHandler = new();
        private readonly AddNewOrderHandler AddNewOrderQueryHandler = new();
        private readonly WebAppDBContext DbContext;

        public OrdersController(WebAppDBContext _DbContext)
        {
            DbContext = _DbContext;
        }

        [HttpPost("ByClient")]
        public async Task<IActionResult> GetOrdersByClient(ViewClientOrdersCommand Request)
        {
            if (Request == null)
            {
                return BadRequest();
            }

            Result<List<ClientOrdersDto>> Response = await ViewClientOrdersQueryHandler.Handle(new GetClientOrdersQuery(DbContext), Request);

            if (Response.Errors.Count > 0)
            {
                return BadRequest(Response.Errors);
            }

            return Ok(Response.Value);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(AddNewOrderCommand Request)
        {
            if (Request == null)
            {
                return BadRequest();
            }

            if (Request.NewOrder == null)
            {
                return BadRequest();
            }

            if (Request.NewOrderDetail == null)
            {
                return BadRequest();
            }

            Result<bool> Response = await AddNewOrderQueryHandler.Handle(new AddNewOrderProcedure(DbContext), Request);

            if (Response.Errors.Count > 0)
            {
                return BadRequest(Response.Errors);
            }

            return Ok(Response.Value);
        }
    }
}
