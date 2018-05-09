using System.Collections.Generic;
using System.Linq;
using WordSmith.WebApi.Domain.Query.Interfaces;
using WordSmith.WebApi.Domain.Query.Queries;
using WordSmith.WebApi.Infrastructure;
using WordSmith.WebApi.Models.ReadModel;

namespace WordSmith.WebApi.Domain.Query.Handlers
{
    public class SessionSentenceQueryHandler : IQueryHandler<SessionSentenceQuery, IEnumerable<Sentence>>
    {
        private readonly SentenceContext _sentenceContext;

        public SessionSentenceQueryHandler(SentenceContext sentenceContext)
        {
            _sentenceContext = sentenceContext;
        }

        public IEnumerable<Sentence> GetResponse(SessionSentenceQuery query)
        {
            return _sentenceContext.Sentences.Where(x => x.SessionId.Equals(query.SessionGuid));
        }
    }
}