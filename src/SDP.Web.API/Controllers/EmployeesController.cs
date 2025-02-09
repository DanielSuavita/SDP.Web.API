using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDP.Web.API.Infrastructure.Data.Queries;
using SDP.Web.API.Infrastructure.Data;
using SDP.Web.API.UseCases.Employees.GetAll;
using SDP.Web.API.UseCases.Employees;

namespace SDP.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly GetAllEmployeesHandler QueryHandler = new();
        private readonly WebAppDBContext DbContext;

        public EmployeesController(WebAppDBContext _DbContext)
        {
            DbContext = _DbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Result<List<EmployeesDto>> Response = await QueryHandler.Handle(new GetEmployeesQuery(DbContext));

            if (Response.Errors.Count > 0)
            {
                return BadRequest(Response.Errors);
            }

            return Ok(Response.Value);
        }
    }
}
