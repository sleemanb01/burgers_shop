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
    public class BurgerController : ControllerBase
    {
        private readonly BurgerShopContext _context;

        public BurgerController(BurgerShopContext context)
        {
            _context = context;
        }

        // GET: api/Burger
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Burger>>> GetBurgers()
        {
          if (_context.Burgers == null)
          {
              return NotFound();
          }
            return await _context.Burgers.ToListAsync();
        }

        // GET: api/Burger/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Burger>> GetBurger(int id)
        {
          if (_context.Burgers == null)
          {
              return NotFound();
          }
            var burger = await _context.Burgers.FindAsync(id);

            if (burger == null)
            {
                return NotFound();
            }

            return burger;
        }

        // PUT: api/Burger/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBurger(int id, Burger burger)
        {
            if (id != burger.Id)
            {
                return BadRequest();
            }

            _context.Entry(burger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BurgerExists(id))
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

        // POST: api/Burger
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("i")]
        public async Task<ActionResult<Burger>> PostBurger(Burger burger)
        {
          if (_context.Burgers == null)
          {
              return Problem("Entity set 'BurgerShopContext.Burgers'  is null.");
          }
            _context.Burgers.Add(burger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBurger", new { id = burger.Id }, burger);
        }

        // DELETE: api/Burger/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBurger(int id)
        {
            if (_context.Burgers == null)
            {
                return NotFound();
            }
            var burger = await _context.Burgers.FindAsync(id);
            if (burger == null)
            {
                return NotFound();
            }

            _context.Burgers.Remove(burger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BurgerExists(int id)
        {
            return (_context.Burgers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
