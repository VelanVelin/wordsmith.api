using System;
using System.Linq;
using WordSmith.WebApi.Domain.Command.Commands;
using WordSmith.WebApi.Domain.Command.Interfaces;
using WordSmith.WebApi.Infrastructure;
using WordSmith.WebApi.Models.WriteModel;

namespace WordSmith.WebApi.Domain.Command.Handlers
{
    public class SaveSentenceCommandHandler : ICommandHandler<SaveSentenceCommand, CommandResponse>
    {
        private readonly SentenceContext _sentenceContext;

        public SaveSentenceCommandHandler(SentenceContext sentenceContext)
        {
            _sentenceContext = sentenceContext;
        }

        public CommandResponse Execute(SaveSentenceCommand command)
        {
            var response = new CommandResponse()
            {
                Success = false
            };

            try
            {
                _sentenceContext.Add(command.Sentence);
                _sentenceContext.SaveChanges();

                response.Id = command.Sentence.Id;
                response.Success = true;
                response.Message = "Persisted sentence successfully";

            }
            catch (Exception ex)
            {
                // log error
            }

            return response;
        }
    }
}