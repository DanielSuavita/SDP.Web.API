using Microsoft.EntityFrameworkCore;
using SDP.Web.API.Infrastructure.Data.Contracts;
using SDP.Web.API.UseCases.Orders;
using SDP.Web.API.UseCases.Shippers;

namespace SDP.Web.API.Infrastructure.Data.Queries
{
    public class GetClientOrdersQuery(WebAppDBContext DbContext) : IGetClientOrders
    {
        public async Task<List<ClientOrdersDto>> GetByClientAsync(int id)
        {
            IQueryable<ClientOrdersDto> Query = DbContext.Database.SqlQuery<ClientOrdersDto>($@"
                SELECT 
                    orderid
                    , requireddate
                    , shippeddate
                    , shipname
                    , shipaddress
                    , shipcity
                FROM [Sales].[GetClientOrders]
                WHERE custid = {id}
            ");
            List<ClientOrdersDto> Data = await Query.ToListAsync();
            return Data;
        }
    }
}
