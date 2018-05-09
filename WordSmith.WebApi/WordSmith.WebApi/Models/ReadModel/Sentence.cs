using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordSmith.WebApi.Models.ReadModel
{
    public class Sentence
    {
        public int Id { get; set; }

        public Guid SessionId { get; set; }

        public string Text { get; set; }

        public string Reversed { get; set; }

        public override string ToString()
        {
            return $"{{ Id: \"{Id}\", SessionId: \"{SessionId.ToString()}\", Text: \"{Text}\", Reversed: \"{Reversed}\"}}";
        }

        public void Reverese()
        {
            try
            {
                if (string.IsNullOrEmpty(this.Text))
                {
                    throw new ArgumentException("Sentence.Text");
                }

                this.Reversed = string.Join("", Regex.Split(this.Text, @"(\W)").Select(x => new string(x.Reverse().ToArray())).ToArray());
            }
            catch (Exception ex)
            {
                // to log
            }
        }
    }
}