using SDP.Web.API.UseCases.Employees;

namespace SDP.Web.API.Infrastructure.Data.Contracts
{
    public interface IGetEmployees
    {
        Task<List<EmployeesDto>> GetEmployeesAsync();
    }
}
