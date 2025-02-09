using SDP.Web.API.UseCases.Customers;

namespace SDP.Web.API.Infrastructure.Data.Contracts
{
    public interface ISalesDatePrediction
    {
        Task<List<SalesDatePredictionDto>> GetAsync();
    }
}
