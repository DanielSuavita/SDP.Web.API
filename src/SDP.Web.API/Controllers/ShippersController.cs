using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDP.Web.API.Infrastructure.Data.Queries;
using SDP.Web.API.Infrastructure.Data;
using SDP.Web.API.UseCases.Shippers.GetAll;
using SDP.Web.API.UseCases.Shippers;

namespace SDP.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly GetAllShippersHandler QueryHandler = new();
        private readonly WebAppDBContext DbContext;

        public ShippersController(WebAppDBContext _DbContext)
        {
            DbContext = _DbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Result<List<ShippersDTO>> Response = await QueryHandler.Handle(new GetShippersQuery(DbContext));

            if (Response.Errors.Count > 0)
            {
                return BadRequest(Response.Errors);
            }

            return Ok(Response.Value);
        }
    }
}
