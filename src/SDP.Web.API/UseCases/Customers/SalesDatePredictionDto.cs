namespace SDP.Web.API.UseCases.Customers
{
    public record SalesDatePredictionDto
    (
        int custid,
        string customername,
        DateTime? lastorderdate,
        DateTime? nextpredictedorder
    );
}
