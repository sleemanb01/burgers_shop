using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurgersShop.Models;

namespace BurgersShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtraController : ControllerBase
    {
        private readonly BurgerShopContext _context;

        public ExtraController(BurgerShopContext context)
        {
            _context = context;
        }

        // GET: api/Extra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Extra>>> GetExtras()
        {
          if (_context.Extras == null)
          {
              return NotFound();
          }
            return await _context.Extras.ToListAsync();
        }

        // GET: api/Extra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Extra>> GetExtra(int id)
        {
          if (_context.Extras == null)
          {
              return NotFound();
          }
            var extra = await _context.Extras.FindAsync(id);

            if (extra == null)
            {
                return NotFound();
            }

            return extra;
        }

        // PUT: api/Extra/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtra(int id, Extra extra)
        {
            if (id != extra.Id)
            {
                return BadRequest();
            }

            _context.Entry(extra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtraExists(id))
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

        // POST: api/Extra
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Extra>> PostExtra(Extra extra)
        {
          if (_context.Extras == null)
          {
              return Problem("Entity set 'BurgerShopContext.Extras'  is null.");
          }
            _context.Extras.Add(extra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtra", new { id = extra.Id }, extra);
        }

        // DELETE: api/Extra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExtra(int id)
        {
            if (_context.Extras == null)
            {
                return NotFound();
            }
            var extra = await _context.Extras.FindAsync(id);
            if (extra == null)
            {
                return NotFound();
            }

            _context.Extras.Remove(extra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExtraExists(int id)
        {
            return (_context.Extras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
