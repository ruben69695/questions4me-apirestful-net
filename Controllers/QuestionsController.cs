using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using questions4me_apirestful_net.Data.Repositories;
using questions4me_apirestful_net.Models;

namespace questions4me_apirestful_net.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly ILogger<QuestionsController> _logger;
        private readonly IQuestionRepository _repository;

        public QuestionsController(ILogger<QuestionsController> logger, IQuestionRepository repository) {
            _logger = logger;
            _repository = repository;
        }

        // GET api/questions
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Question>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Question>>> Get() {
            var data = await _repository.GetAll()
                .ToListAsync();
            
            return data;
        }

        // GET api/questions/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Question), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Question>> Get(int id) {
            var data = await _repository.GetAll()
                .FirstOrDefaultAsync(question => question.Id == id);
            
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound);
            else
                return data;
        }

        // POST api/questions
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody]Question item) {
            if (item == null) {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            else if (string.IsNullOrWhiteSpace(item.Content)) {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }

            item.CreatedAt = DateTime.UtcNow;
            if (string.IsNullOrWhiteSpace(item.CreatedBy)) {
                item.CreatedBy = "Anonymous";
            }
            
            try {
                await _repository.Create(item);
            }
            catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return StatusCode(StatusCodes.Status201Created);
        }

    }
}