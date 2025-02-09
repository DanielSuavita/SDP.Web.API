using System.ComponentModel.DataAnnotations;

namespace SDP.Web.API.UseCases.Orders
{
    public record NewOrderDetailDto
    (
        int orderid,
        int productid,
        decimal unitprice,
        int qty,
        decimal discount
    );
}
