using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDP.Web.API.Infrastructure.Data;
using SDP.Web.API.Infrastructure.Data.Queries;
using SDP.Web.API.UseCases.Customers;
using SDP.Web.API.UseCases.Customers.GetSalesDatePrediction;

namespace SDP.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly GetSaLesDatePredictionHandler QueryHandler = new();
        private readonly WebAppDBContext DbContext;

        public CustomersController(WebAppDBContext _DbContext)
        {
            DbContext = _DbContext;
        }

        [HttpGet("SalesDatePrediction")]
        public async Task<IActionResult> GetSalesDatePrediction()
        {
            Result<List<SalesDatePredictionDto>> Response = await QueryHandler.Handle(new GetSalesDatePrediction(DbContext));

            if (Response.Errors.Count > 0)
            {
                return BadRequest(Response.Errors);
            }

            return Ok(Response.Value);
        }
    }
}
