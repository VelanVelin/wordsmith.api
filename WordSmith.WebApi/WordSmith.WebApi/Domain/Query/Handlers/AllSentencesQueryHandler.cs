using System.Collections.Generic;
using System.Linq;
using WordSmith.WebApi.Domain.Query.Interfaces;
using WordSmith.WebApi.Domain.Query.Queries;
using WordSmith.WebApi.Infrastructure;
using WordSmith.WebApi.Models.ReadModel;

namespace WordSmith.WebApi.Domain.Query.Handlers
{
    public class AllSentencesQueryHandler : IQueryHandler<AllSentencesQuery, IEnumerable<Sentence>>
    {
        private readonly SentenceContext _sentenceContext;

        public AllSentencesQueryHandler(SentenceContext sentenceContext)
        {
            _sentenceContext = sentenceContext;
        }

        public IEnumerable<Sentence> GetResponse(AllSentencesQuery query)
        {
            var sentences = _sentenceContext.Sentences.ToList();

            return sentences;
        }
    }
}
