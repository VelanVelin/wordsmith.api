namespace WordSmith.WebApi.Domain.Query.Interfaces
{
    public interface IQueryHandler<in TQuery, out TResponse> where TQuery : IQuery<TResponse>
    {
        TResponse GetResponse(TQuery query);
    }
}