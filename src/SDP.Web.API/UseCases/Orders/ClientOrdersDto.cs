namespace SDP.Web.API.UseCases.Orders
{
    public record ClientOrdersDto
    (
        int orderid,
        DateTime? requireddate,
        DateTime? shippeddate,
        string shipname,
        string shipaddress,
        string shipcity
    );
}
