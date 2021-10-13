using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lucky_DannyMarceloDávilaBarrancos.Data;
using Lucky_DannyMarceloDávilaBarrancos.Models;

namespace Lucky_DannyMarceloDávilaBarrancos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuckyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LuckyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Lucky
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lucky>>> GetLucky()
        {
            return await _context.Lucky.ToListAsync();
        }

        // GET: api/Lucky/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lucky>> GetLucky(string id)
        {
            var lucky = await _context.Lucky.FindAsync(id);

            if (lucky == null)
            {
                return NotFound();
            }

            return lucky;
        }

        // PUT: api/Lucky/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLucky(string id, Lucky lucky)
        {
            if (id != lucky.SuerteID)
            {
                return BadRequest();
            }

            _context.Entry(lucky).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LuckyExists(id))
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

        // POST: api/Lucky
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lucky>> PostLucky(Lucky lucky)
        {
            _context.Lucky.Add(lucky);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LuckyExists(lucky.SuerteID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLucky", new { id = lucky.SuerteID }, lucky);
        }

        // DELETE: api/Lucky/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLucky(string id)
        {
            var lucky = await _context.Lucky.FindAsync(id);
            if (lucky == null)
            {
                return NotFound();
            }

            _context.Lucky.Remove(lucky);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LuckyExists(string id)
        {
            return _context.Lucky.Any(e => e.SuerteID == id);
        }
    }
}
