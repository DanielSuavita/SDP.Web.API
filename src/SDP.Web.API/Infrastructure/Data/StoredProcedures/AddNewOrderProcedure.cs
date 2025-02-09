using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SDP.Web.API.Infrastructure.Data.Contracts;
using SDP.Web.API.Infrastructure.Data.Mappers;
using SDP.Web.API.UseCases.Orders;
using System.Data;

namespace SDP.Web.API.Infrastructure.Data.StoredProcedures
{
    public class AddNewOrderProcedure(WebAppDBContext DbContext) : IAddNewOrder
    {
        public async Task<bool> Create(NewOrderDto NewOrder, NewOrderDetailDto NewOrderDetail)
        {
            bool Completed = false;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                SqlParameter NewOrderParam = Converter.ConvertToStructuredSQLParameter(
                    Converter.ConvertToDataTable(NewOrder),
                    "@Order",
                    "[Sales].[Orders]"
                );

                SqlParameter NewOrderDetailParam = Converter.ConvertToStructuredSQLParameter(
                    Converter.ConvertToDataTable(NewOrderDetail),
                    "@OrderDetails",
                    "[Sales].[OrderDetails]"
                );

                parameters.Add(NewOrderParam);
                parameters.Add(NewOrderDetailParam);

                await DbContext.Database.BeginTransactionAsync();

                await DbContext.Database.ExecuteSqlRawAsync($"EXEC Sales.AddNewOrder @Order, @OrderDetails", parameters);

                await DbContext.Database.CommitTransactionAsync();

                Completed = true;
            } catch
            {

                await DbContext.Database.RollbackTransactionAsync();
                Completed = false;
            }

            return Completed;
        }
    }
}
