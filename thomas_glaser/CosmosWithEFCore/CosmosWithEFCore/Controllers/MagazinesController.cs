using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CosmosWithEFCore.Models;

namespace CosmosWithEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagazinesController : ControllerBase
    {
        private readonly BooksContext _context;

        public MagazinesController(BooksContext context)
        {
            _context = context;
        }

        // GET: api/Magazines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Magazine>>> GetMagazines()
        {
            return await _context.Magazines.ToListAsync();
        }

        // GET: api/Magazines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Magazine>> GetMagazine(int id)
        {
            var magazine = await _context.Magazines.FindAsync(id);

            if (magazine == null)
            {
                return NotFound();
            }

            return magazine;
        }

        // PUT: api/Magazines/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagazine(int id, Magazine magazine)
        {
            if (id != magazine.Id)
            {
                return BadRequest();
            }

            _context.Entry(magazine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Magazines
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Magazine>> PostMagazine(Magazine magazine)
        {
            _context.Magazines.Add(magazine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMagazine", new { id = magazine.Id }, magazine);
        }

        // DELETE: api/Magazines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Magazine>> DeleteMagazine(int id)
        {
            var magazine = await _context.Magazines.FindAsync(id);
            if (magazine == null)
            {
                return NotFound();
            }

            _context.Magazines.Remove(magazine);
            await _context.SaveChangesAsync();

            return magazine;
        }

        private bool MagazineExists(int id)
        {
            return _context.Magazines.Any(e => e.Id == id);
        }
    }
}
