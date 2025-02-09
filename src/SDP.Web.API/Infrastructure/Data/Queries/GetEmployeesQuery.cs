using Microsoft.EntityFrameworkCore;
using SDP.Web.API.Infrastructure.Data.Contracts;
using SDP.Web.API.UseCases.Employees;

namespace SDP.Web.API.Infrastructure.Data.Queries
{
    public class GetEmployeesQuery(WebAppDBContext DbContext) : IGetEmployees
    {
        public async Task<List<EmployeesDto>> GetEmployeesAsync()
        {
            IQueryable<EmployeesDto> Query = DbContext.Database.SqlQuery<EmployeesDto>($"SELECT empid, FullName FROM [HR].[GetEmployees]");
            List<EmployeesDto> Data = await Query.ToListAsync();
            return Data;
        }
    }
}
