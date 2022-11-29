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
    public class SideController : ControllerBase
    {
        private readonly BurgerShopContext _context;

        public SideController(BurgerShopContext context)
        {
            _context = context;
        }

        // GET: api/Side
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Side>>> GetSides()
        {
          if (_context.Sides == null)
          {
              return NotFound();
          }
            return await _context.Sides.ToListAsync();
        }

        // GET: api/Side/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Side>> GetSide(int id)
        {
          if (_context.Sides == null)
          {
              return NotFound();
          }
            var side = await _context.Sides.FindAsync(id);

            if (side == null)
            {
                return NotFound();
            }

            return side;
        }

        // PUT: api/Side/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSide(int id, Side side)
        {
            if (id != side.Id)
            {
                return BadRequest();
            }

            _context.Entry(side).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SideExists(id))
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

        // POST: api/Side
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Side>> PostSide(Side side)
        {
          if (_context.Sides == null)
          {
              return Problem("Entity set 'BurgerShopContext.Sides'  is null.");
          }
            _context.Sides.Add(side);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSide", new { id = side.Id }, side);
        }

        // DELETE: api/Side/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSide(int id)
        {
            if (_context.Sides == null)
            {
                return NotFound();
            }
            var side = await _context.Sides.FindAsync(id);
            if (side == null)
            {
                return NotFound();
            }

            _context.Sides.Remove(side);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SideExists(int id)
        {
            return (_context.Sides?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
