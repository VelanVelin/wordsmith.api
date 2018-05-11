using System.Collections.Generic;
using System.Linq;
using WordSmith.WebApi.Domain.Query.Interfaces;
using WordSmith.WebApi.Domain.Query.Queries;
using WordSmith.WebApi.Infrastructure;
using WordSmith.WebApi.Models.ReadModel;

namespace WordSmith.WebApi.Domain.Query.Handlers
{
    public class ByIdSentenceQueryHandler : IQueryHandler<ByIdSentenceQuery, Sentence>
    {
        private readonly SentenceContext _sentenceContext;

        public ByIdSentenceQueryHandler(SentenceContext sentenceContext)
        {
            _sentenceContext = sentenceContext;
        }

        public Sentence GetResponse(ByIdSentenceQuery query)
        {
            return _sentenceContext.Sentences.FirstOrDefault(x => x.Id == query.Id);
        }
    }
}