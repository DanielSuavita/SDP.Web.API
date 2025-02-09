using Microsoft.EntityFrameworkCore;
using SDP.Web.API.Infrastructure.Data.Contracts;
using SDP.Web.API.UseCases.Employees;
using SDP.Web.API.UseCases.Shippers;

namespace SDP.Web.API.Infrastructure.Data.Queries
{
    public class GetShippersQuery(WebAppDBContext DbContext) : IGetShippers
    {
        public async Task<List<ShippersDTO>> GetAllAsync()
        {
            IQueryable<ShippersDTO> Query = DbContext.Database.SqlQuery<ShippersDTO>($"SELECT shipperid, companyname FROM [Sales].[GetShippers]");
            List<ShippersDTO> Data = await Query.ToListAsync();
            return Data;
        }
    }
}
