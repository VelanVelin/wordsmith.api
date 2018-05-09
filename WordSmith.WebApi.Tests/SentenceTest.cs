using System;
using WordSmith.WebApi.Models.ReadModel;
using Xunit;

namespace WordSmith.WebApi.Tests
{
    public class SentenceTest
    {
        [Fact]
        public void GivenNormalExistWhenRevereseSentence()
        {
            var sentence = new Sentence()
            {
                Text = "The red fox crosses the ice, intent on none of my business.",
            };
            sentence.Reverese();
            Console.WriteLine(sentence.ToString());
            Assert.Equal("ehT der xof sessorc eht eci, tnetni no enon fo ym ssenisub.", sentence.Reversed);
            
        }
    }
}