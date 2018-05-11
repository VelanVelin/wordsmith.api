using WordSmith.WebApi.Domain.Command.Interfaces;
using WordSmith.WebApi.Models.ReadModel;
using WordSmith.WebApi.Models.WriteModel;

namespace WordSmith.WebApi.Domain.Command.Commands
{
    public class SaveSentenceCommand : ICommand<CommandResponse>
    {
        public Sentence Sentence { get; set; }
    }
}