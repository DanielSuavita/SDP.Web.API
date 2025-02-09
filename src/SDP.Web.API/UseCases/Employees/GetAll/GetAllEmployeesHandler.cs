using FluentResults;
using SDP.Web.API.Infrastructure.Data.Queries;

namespace SDP.Web.API.UseCases.Employees.GetAll
{
    public class GetAllEmployeesHandler : IQueryHandler<GetEmployeesQuery, Result<List<EmployeesDto>>>
    {
        public async Task<Result<List<EmployeesDto>>> Handle(GetEmployeesQuery query)
        {
            List<EmployeesDto> Employees = await query.GetEmployeesAsync();

            if (Employees == null)
            {
                return new Error("No hay Empleados");
            }

            return Result.Ok(Employees);
        }
    }
}
