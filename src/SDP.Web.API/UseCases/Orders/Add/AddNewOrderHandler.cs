using FluentResults;
using SDP.Web.API.Infrastructure.Data.StoredProcedures;

namespace SDP.Web.API.UseCases.Orders.Add
{
    public class AddNewOrderHandler : IQueryHandler<AddNewOrderProcedure, AddNewOrderCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(AddNewOrderProcedure query, AddNewOrderCommand command)
        {
            bool Inserted = await query.Create(command.NewOrder, command.NewOrderDetail);

            if (!Inserted)
            {
                return new Error("Hubo un error en el procesamiento de la nueva orden");
            }

            return Result.Ok(Inserted);
        }
    }
}
