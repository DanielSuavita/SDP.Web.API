namespace SDP.Web.API.UseCases.Orders
{
    public record NewOrderDto
    (
        int empid,
        int shipperid,
        string shipname,
        string shipaddress,
        string shipcity,
        DateTime orderdate,
        DateTime requireddate,
        DateTime shippeddate,
        decimal freight,
        string shipcountry,
        int custid
    );
}
