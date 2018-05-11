using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly IQueryHandler<BySessionSentenceQuery, IEnumerable<Sentence>> _getSessionQueryHandler;
        private readonly IQueryHandler<ByIdSentenceQuery, Sentence> _getByIdQueryHandler;
        private readonly ICommandHandler<SaveSentenceCommand, CommandResponse> _createCommandHandler;
        private readonly ILogger<ReverseController> _logger;

        public ReverseController(
            IQueryHandler<AllSentencesQuery, IEnumerable<Sentence>> getAllQueryHandler, 
            IQueryHandler<BySessionSentenceQuery, IEnumerable<Sentence>> getSessionQueryHandler, 
            IQueryHandler<ByIdSentenceQuery, Sentence> getByIdQueryHandler, 
            ICommandHandler<SaveSentenceCommand, CommandResponse> createCommandHandler, 
            ILogger<ReverseController> logger)
        {
            _getAllQueryHandler = getAllQueryHandler;
            _getSessionQueryHandler = getSessionQueryHandler;
            _getByIdQueryHandler = getByIdQueryHandler;
            _createCommandHandler = createCommandHandler;
            _logger = logger;
            
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
            try
            {
                return Ok(_getSessionQueryHandler.GetResponse(new BySessionSentenceQuery()
                {
                    SessionGuid = new Guid(sessionId)
                }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        // GET: api/Reverse/12
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                _logger.LogWarning("IN GET BY ID!");
                return Ok(_getByIdQueryHandler.GetResponse(new ByIdSentenceQuery()
                {
                    Id = id
                }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        // POST: api/Reverse
        [HttpPost]
        public IActionResult Post([FromBody] Sentence sentence)
        {
            try
            {
                sentence.Reverese();
                var response = _createCommandHandler.Execute(new SaveSentenceCommand()
                {
                    Sentence = sentence
                });
                if (response.Success)
                {
                    //sentence.Id = response.Id;
                    return Ok(response.Id);
                }
                else
                {
                    _logger.LogError(response.Message);
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
            
        }
    }
}
