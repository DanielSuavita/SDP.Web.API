using FluentResults;
using SDP.Web.API.Infrastructure.Data.Queries;
using SDP.Web.API.UseCases.Shippers;

namespace SDP.Web.API.UseCases.Shippers.GetAll
{
    public class GetAllShippersHandler : IQueryHandler<GetShippersQuery, Result<List<ShippersDTO>>>
    {
        public async Task<Result<List<ShippersDTO>>> Handle(GetShippersQuery query)
        {
            List<ShippersDTO> Shippers = await query.GetAllAsync();

            if (Shippers == null)
            {
                return new Error("No hay Productos");
            }

            return Result.Ok(Shippers);
        }
    }
}
