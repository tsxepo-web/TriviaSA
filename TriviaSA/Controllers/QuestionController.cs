using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaSA.Core.Entities;
using TriviaSA.Core.Interfaces;

namespace TriviaSA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Questions>>> GetQuestions()
        {
            var questions = await _questionService.GetQuestionsAsync();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Questions>> GetQuestionById(string id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null) return NotFound();
            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] Questions question)
        {
            await _questionService.CreateQuestionAsync(question);
            return CreatedAtAction(nameof(GetQuestionById), new { id = question.Id }, question);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(string id, [FromBody] Questions question)
        {
            if (id != question.Id) return BadRequest();
            await _questionService.UpdateQuestionAsync(question);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(string id)
        {
            await _questionService.DeleteQuestionAsync(id);
            return NoContent();
        }

        [HttpGet("random")]
        public async Task<ActionResult<Questions>> GetRandomQuestion()
        {
            var question = await _questionService.GetRandomQuestionAsync();
            return Ok(question);
        }
    }
}
