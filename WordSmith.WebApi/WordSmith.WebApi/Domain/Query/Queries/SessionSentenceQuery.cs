using System;
using System.Collections.Generic;
using WordSmith.WebApi.Domain.Query.Interfaces;
using WordSmith.WebApi.Models.ReadModel;

namespace WordSmith.WebApi.Domain.Query.Queries
{
    public class SessionSentenceQuery : IQuery<IEnumerable<Sentence>>
    {
        public Guid SessionGuid { get; set; }
    }
}