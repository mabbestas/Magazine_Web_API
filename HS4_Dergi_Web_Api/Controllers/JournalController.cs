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
    public class JournalController : ControllerBase
    {
        private readonly JournalDBContext _journalDBContext;

        public JournalController(JournalDBContext journalDBContext)
        {
            _journalDBContext = journalDBContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Journal>>> Get()
        {
            var result =  await _journalDBContext.Journals.ToListAsync();

            if (result.Count < 1)
                return NoContent();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Journal>> Get(int id)
        {
            var result = await _journalDBContext.Journals.FirstOrDefaultAsync(x => x.Id == id);

            if (result is null)
                return NotFound();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Journal>> Post([FromBody] Journal journal)
        {
            await _journalDBContext.Journals.AddAsync(journal);
            await _journalDBContext.SaveChangesAsync();
           return journal;           
        }

        [HttpPut]
        public async Task<ActionResult<Journal>> Put([FromBody] Journal journal)
        {
            _journalDBContext.Entry(journal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _journalDBContext.SaveChangesAsync();
            return journal;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedJournal = await _journalDBContext.Journals.FirstOrDefaultAsync(x => x.Id == id);

            if (deletedJournal is null)
            {
               return NotFound();
            }
            else
            {
            _journalDBContext.Journals.Remove(deletedJournal);
            await _journalDBContext.SaveChangesAsync();
               return Ok();
            }
        }
    }
}
