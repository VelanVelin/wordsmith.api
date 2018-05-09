using System.Collections;
using System.Collections.Generic;
using WordSmith.WebApi.Models;
using WordSmith.WebApi.Models.ReadModel;

namespace WordSmith.WebApi.Infrastructure
{
    public static class MockSentenceDb
    {
        public static IEnumerable<Sentence> Sentences { get; }
        public static int UniqueId = 2;

        static MockSentenceDb()
        {
            Sentences = new List<Sentence>()
            {
                new Sentence
                {
                    Id = 1,
                    Text = "The red fox crosses the ice, intent on none of my business.",
                    Reversed = "ehT der xof sessorc eht eci, tnetni no enon fo ym ssenisub."
                }
            };
        }
        //public List<Sentence> GetAllSentences()
        //{
        //    return new List<Sentence>()
        //    {
        //        new Sentence
        //        {
        //            Id = 1,
        //            Text = "The red fox crosses the ice, intent on none of my business.",
        //            Reversed = "ehT der xof sessorc eht eci, tnetni no enon fo ym ssenisub."
        //        },

        //    };
        //}
    }
}