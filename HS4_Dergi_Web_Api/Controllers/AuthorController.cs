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
    public class AuthorController : Controller
    {
        private readonly JournalDBContext _journalDBContext;

        public AuthorController(JournalDBContext journalDBContext)
        {
            _journalDBContext = journalDBContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> Get()
        {
            var result = await _journalDBContext.Authors.ToListAsync();

            if (result.Count < 1)
                return NoContent();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            var result = await _journalDBContext.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if (result is null)
                return NotFound();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Author>> Post([FromBody] Author author)
        {
            await _journalDBContext.Authors.AddAsync(author);
            await _journalDBContext.SaveChangesAsync();
            return author;
        }

        [HttpPut]
        public async Task<ActionResult<Author>> Put([FromBody] Author author)
        {
            _journalDBContext.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _journalDBContext.SaveChangesAsync();
            return author;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedAuthor = await _journalDBContext.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if (deletedAuthor is null)
            {
                return NotFound();
            }
            else
            {
                _journalDBContext.Authors.Remove(deletedAuthor);
                await _journalDBContext.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
