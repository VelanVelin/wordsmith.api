using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using WordSmith.WebApi.Domain.Command.Commands;
using WordSmith.WebApi.Domain.Query.Queries;
using WordSmith.WebApi.Models.ReadModel;
using WordSmith.WebApi.Domain.Command.Interfaces;
using WordSmith.WebApi.Domain.Query.Interfaces;
using WordSmith.WebApi.Models.WriteModel;


namespace WordSmith.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ReverseController : Controller
    {
        private readonly IQueryHandler<AllSentencesQuery, IEnumerable<Sentence>> _getAllQueryHandler;
        private readonly IQueryHandler<SessionSentenceQuery, IEnumerable<Sentence>> _getSessionQueryHandler;
        private readonly ICommandHandler<SaveSentenceCommand, CommandResponse> _createCommandHandler;

        public ReverseController(IQueryHandler<AllSentencesQuery, IEnumerable<Sentence>> getAllQueryHandler, IQueryHandler<SessionSentenceQuery, IEnumerable<Sentence>> getSessionQueryHandler, ICommandHandler<SaveSentenceCommand, CommandResponse> createCommandHandler)
        {
            _getAllQueryHandler = getAllQueryHandler;
            _getSessionQueryHandler = getSessionQueryHandler;
            _createCommandHandler = createCommandHandler;
        }

        // GET: api/Reverse
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_getAllQueryHandler.GetResponse(new AllSentencesQuery()));
        }


        // GET: api/Reverse/18F9D772-C1BE-45E5-B28C-8D724CFEFD7C
        [HttpGet("{sessionId}")]
        public IActionResult GetBySessionId(string sessionId)
        {
            return Ok(_getSessionQueryHandler.GetResponse(new SessionSentenceQuery()
            {
                SessionGuid = new Guid(sessionId)
            }));
        }


        // POST: api/Reverse
        [HttpPost]
        public IActionResult Post([FromBody] Sentence sentence)
        {
            sentence.Reverese();
            var response = _createCommandHandler.Execute(new SaveSentenceCommand()
            {
                Sentence = sentence
            });
            if (response.Success)
            {
                sentence.Id = response.Id;
                return Ok(sentence);
            }

            var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(response.Message),
                ReasonPhrase = "InternalServerError"
            };
            //throw new HttpResponseException(message);
            return Ok();
        }
    }
}
