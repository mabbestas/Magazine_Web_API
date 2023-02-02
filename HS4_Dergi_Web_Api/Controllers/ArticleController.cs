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
    public class ArticleController : Controller
    {
        private readonly JournalDBContext _journalDBContext;

        public ArticleController(JournalDBContext journalDBContext)
        {
            _journalDBContext = journalDBContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> Get()
        {
            var result = await _journalDBContext.Articles.ToListAsync();

            if (result.Count < 1)
                return NoContent();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> Get(int id)
        {
            var result = await _journalDBContext.Articles.FirstOrDefaultAsync(x => x.Id == id);

            if (result is null)
                return NotFound();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Article>> Post([FromBody] Article article)
        {
            await _journalDBContext.Articles.AddAsync(article);
            await _journalDBContext.SaveChangesAsync();
            return article;
        }

        [HttpPut]
        public async Task<ActionResult<Article>> Put([FromBody] Article article)
        {
            _journalDBContext.Entry(article).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _journalDBContext.SaveChangesAsync();
            return article;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedArticles = await _journalDBContext.Articles.FirstOrDefaultAsync(x => x.Id == id);

            if (deletedArticles is null)
            {
                return NotFound();
            }
            else
            {
                _journalDBContext.Articles.Remove(deletedArticles);
                await _journalDBContext.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
