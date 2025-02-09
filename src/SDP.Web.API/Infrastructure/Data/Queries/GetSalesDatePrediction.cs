using Microsoft.EntityFrameworkCore;
using SDP.Web.API.Infrastructure.Data.Contracts;
using SDP.Web.API.UseCases.Customers;

namespace SDP.Web.API.Infrastructure.Data.Queries
{
    public class GetSalesDatePrediction(WebAppDBContext DbContext) : ISalesDatePrediction
    {
        public async Task<List<SalesDatePredictionDto>> GetAsync()
        {
            IQueryable<SalesDatePredictionDto> Query = DbContext.Database.SqlQuery<SalesDatePredictionDto>($@"
                SELECT 
                    customername
                    , lastorderdate
                    , nextpredictedorder 
                    , custid
                FROM [Sales].[SalesDatePrediction] 
                ORDER BY lastorderdate DESC
            ");

            List<SalesDatePredictionDto> Data = await Query.ToListAsync();

            return Data;
        }
    }
}
