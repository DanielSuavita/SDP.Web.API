using FluentResults;
using SDP.Web.API.Infrastructure.Data.Queries;

namespace SDP.Web.API.UseCases.Orders.View
{
    public class ViewClientOrdersHandler : IQueryHandler<GetClientOrdersQuery, ViewClientOrdersCommand, Result<List<ClientOrdersDto>>>
    {
        public async Task<Result<List<ClientOrdersDto>>> Handle(GetClientOrdersQuery query, ViewClientOrdersCommand command)
        {
            List<ClientOrdersDto> ClientOrders = await query.GetByClientAsync(command.id);

            if (ClientOrders == null)
            {
                return new Error("Este Cliente no tiene Ordenes");
            }

            return Result.Ok(ClientOrders);
        }
    }
}
