using FluentResults;
using SDP.Web.API.Infrastructure.Data.Contracts;
using SDP.Web.API.Infrastructure.Data.Queries;

namespace SDP.Web.API.UseCases.Customers.GetSalesDatePrediction
{
    public class GetSaLesDatePredictionHandler : IQueryHandler<ISalesDatePrediction, Result<List<SalesDatePredictionDto>>>
    {
        public async Task<Result<List<SalesDatePredictionDto>>> Handle(ISalesDatePrediction query)
        {
            List<SalesDatePredictionDto> SalesDatePrediction = await query.GetAsync();

            if (SalesDatePrediction == null)
            {
                return new Error("No hay Registros para la predicción");
            }

            return Result.Ok(SalesDatePrediction);
        }
    }
}
