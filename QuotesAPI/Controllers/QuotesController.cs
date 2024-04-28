using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using QuotesAPI.Data.Models;
using QuotesAPI.Repository.IRepository;

namespace QuotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteRepository _quoteRepository;
        public QuotesController(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Quote> quotes;
            quotes = await _quoteRepository.GetAllAsync();
            return Ok(quotes);
        }
        [HttpPost]
        public async Task<IActionResult> AddQuote([FromBody]Quote quote)
        {
            Quote model = new Quote()
            {
                Author = quote.Author,
                Description = quote.Description
            };
            await _quoteRepository.AddAsync(model);
            return CreatedAtAction("AddQuote", new {id = model.Id}, model);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            var quote = await _quoteRepository.GetAsync(q => q.Id == id);
            if (quote == null)
            {
                return NotFound();
            }
            await _quoteRepository.RemoveAsync(quote);
            return Ok("Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateQuote(int id, [FromBody] Quote quoteDTO)
        {
            if (quoteDTO == null || id != quoteDTO.Id)
            {
                return BadRequest();
            }
            Quote quoteToUpdate = await _quoteRepository.GetAsync(q => q.Id == quoteDTO.Id);
            quoteToUpdate.Author = quoteDTO.Author;
            quoteToUpdate.Description = quoteDTO.Description;
           
            await _quoteRepository.Update(quoteToUpdate);
            return Ok($"{quoteToUpdate.Author}: {quoteToUpdate.Description} - Updated");
        }      
    }
}
