using System.Collections.Generic;
using WordSmith.WebApi.Domain.Query.Interfaces;
using WordSmith.WebApi.Models.ReadModel;

namespace WordSmith.WebApi.Domain.Query.Queries
{
    public class ByIdSentenceQuery : IQuery<Sentence>
    {
        public int Id { get; set; }
    }
}