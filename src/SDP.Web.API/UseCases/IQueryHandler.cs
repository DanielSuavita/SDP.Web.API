namespace SDP.Web.API.UseCases
{
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<TResult> Handle(TQuery query);
    }

    public interface IQueryHandler<TQuery, TCommand, TResult>
    {
        Task<TResult> Handle(TQuery query, TCommand command);
    }
}
