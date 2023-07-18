using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quickjournal_backend.Models;
using Sieve.Models;
using Sieve.Services;

namespace quickjournal_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly QuickjournalContext _context;
        private readonly SieveProcessor _sieveProcessor;

        public EntryController(QuickjournalContext context, SieveProcessor sieveProcessor)
        {
            _context = context;
            _sieveProcessor = sieveProcessor;
        }

        // GET: api/Entry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entry>>> GetEntries([FromQuery] SieveModel sieveModel)
        {
            var result = _context.Entries.AsNoTracking();

            result = _sieveProcessor.Apply(sieveModel, result);
            return await result.ToListAsync();
        }

        // GET: api/Entry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entry>> GetEntry(Guid id)
        {
            if (_context.Entries == null)
            {
                return NotFound();
            }
            var entry = await _context.Entries.FindAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            return entry;
        }

        // PUT: api/Entry/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntry(Guid id, Entry entry)
        {
            if (id != entry.Id)
            {
                return BadRequest();
            }

            _context.Entry(entry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(id))
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

        // POST: api/Entry
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Entry>> PostEntry(Entry entry)
        {
            if (_context.Entries == null)
            {
                return Problem("Entity set 'QuickjournalContext.Entries'  is null.");
            }
            _context.Entries.Add(entry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntry", new { id = entry.Id }, entry);
        }

        // DELETE: api/Entry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry(Guid id)
        {
            if (_context.Entries == null)
            {
                return NotFound();
            }
            var entry = await _context.Entries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }

            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntryExists(Guid id)
        {
            return (_context.Entries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
