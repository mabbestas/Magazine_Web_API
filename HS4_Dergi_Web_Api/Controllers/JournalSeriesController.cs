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
    public class JournalSeriesController : Controller
    {
        private readonly JournalDBContext _journalDBContext;

        public JournalSeriesController(JournalDBContext journalDBContext)
        {
            _journalDBContext = journalDBContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<JournalSeries>>> Get()
        {
            var result = await _journalDBContext.JournalSeries.ToListAsync();

            if (result.Count < 1)
                return NoContent();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JournalSeries>> Get(int id)
        {
            var result = await _journalDBContext.JournalSeries.FirstOrDefaultAsync(x => x.Id == id);

            if (result is null)
                return NotFound();
            return result;
        }

        //[HttpGet("{journalId}")]
        [HttpGet("GetByJournalId33/{journalId}")]
        public async Task<ActionResult<List<JournalSeries>>> GetByJournalId(int journalId)
        {
            var result = await _journalDBContext.JournalSeries.Where(x => x.JournalId == journalId).ToListAsync();

            if (result is null)
                return NotFound();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<JournalSeries>> Post([FromBody] JournalSeries journalSeries)
        {
            await _journalDBContext.JournalSeries.AddAsync(journalSeries);
            await _journalDBContext.SaveChangesAsync();
            return journalSeries;
        }

        [HttpPut]
        public async Task<ActionResult<JournalSeries>> Put([FromBody] JournalSeries journalSeries)
        {
            _journalDBContext.Entry(journalSeries).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _journalDBContext.SaveChangesAsync();
            return journalSeries;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedJournalSeries = await _journalDBContext.JournalSeries.FirstOrDefaultAsync(x => x.Id == id);

            if (deletedJournalSeries is null)
            {
                return NotFound();
            }
            else
            {
                _journalDBContext.JournalSeries.Remove(deletedJournalSeries);
                await _journalDBContext.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
