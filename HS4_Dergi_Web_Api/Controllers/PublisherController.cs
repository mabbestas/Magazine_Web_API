using HS4_Dergi_Web_Api.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS4_Dergi_Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : Controller
    {
        private readonly JournalDBContext _journalDBContext;

        public PublisherController(JournalDBContext journalDBContext)
        {
            _journalDBContext = journalDBContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Publisher>>> Get()
        {
            var result = await _journalDBContext.Publishers.ToListAsync();

            if (result.Count < 1)
                return NoContent();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> Get(int id)
        {
            var result = await _journalDBContext.Publishers.FirstOrDefaultAsync(x => x.Id == id);

            if (result is null)
                return NotFound();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Publisher>> Post([FromBody] Publisher publisher)
        {
            await _journalDBContext.Publishers.AddAsync(publisher);
            await _journalDBContext.SaveChangesAsync();
            return publisher;
        }

        [HttpPut]
        public async Task<ActionResult<Publisher>> Put([FromBody] Publisher publisher)
        {
            _journalDBContext.Entry(publisher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _journalDBContext.SaveChangesAsync();
            return publisher;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedPublisher = await _journalDBContext.Publishers.FirstOrDefaultAsync(x => x.Id == id);

            if (deletedPublisher is null)
            {
                return NotFound();
            }
            else
            {
                _journalDBContext.Publishers.Remove(deletedPublisher);
                await _journalDBContext.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
