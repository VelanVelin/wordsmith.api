namespace WordSmith.WebApi.Domain.Query.Interfaces
{
    public interface IQueryProcessor
    {
        TResult Process<TResult>(IQuery<TResult> query);
    }
}