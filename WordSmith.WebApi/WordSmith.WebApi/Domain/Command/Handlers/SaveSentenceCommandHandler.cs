using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using WordSmith.WebApi.Domain.Command.Commands;
using WordSmith.WebApi.Domain.Command.Interfaces;
using WordSmith.WebApi.Infrastructure;
using WordSmith.WebApi.Models.WriteModel;

namespace WordSmith.WebApi.Domain.Command.Handlers
{
    public class SaveSentenceCommandHandler : ICommandHandler<SaveSentenceCommand, CommandResponse>
    {
        private readonly SentenceContext _sentenceContext;
        private readonly ILogger<SaveSentenceCommandHandler> _logger;

        public SaveSentenceCommandHandler(SentenceContext sentenceContext, ILogger<SaveSentenceCommandHandler> logger)
        {
            _sentenceContext = sentenceContext;
            _logger = logger;
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

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error occured when persisting data";
                _logger.LogCritical(ex, ex.Message);
                return response;
            }
        }
    }
}