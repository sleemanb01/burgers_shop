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
    public class OrderExtraController : ControllerBase
    {
        private readonly BurgerShopContext _context;

        public OrderExtraController(BurgerShopContext context)
        {
            _context = context;
        }

        // GET: api/OrderExtra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderExtra>>> GetOrderExtras()
        {
          if (_context.OrderExtras == null)
          {
              return NotFound();
          }
            return await _context.OrderExtras.ToListAsync();
        }

        // GET: api/OrderExtra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderExtra>> GetOrderExtra(int id)
        {
          if (_context.OrderExtras == null)
          {
              return NotFound();
          }
            var orderExtra = await _context.OrderExtras.FindAsync(id);

            if (orderExtra == null)
            {
                return NotFound();
            }

            return orderExtra;
        }

        // PUT: api/OrderExtra/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderExtra(int id, OrderExtra orderExtra)
        {
            if (id != orderExtra.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderExtra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExtraExists(id))
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

        // POST: api/OrderExtra
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderExtra>> PostOrderExtra(OrderExtra orderExtra)
        {
          if (_context.OrderExtras == null)
          {
              return Problem("Entity set 'BurgerShopContext.OrderExtras'  is null.");
          }
            _context.OrderExtras.Add(orderExtra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderExtra", new { id = orderExtra.Id }, orderExtra);
        }

        // DELETE: api/OrderExtra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderExtra(int id)
        {
            if (_context.OrderExtras == null)
            {
                return NotFound();
            }
            var orderExtra = await _context.OrderExtras.FindAsync(id);
            if (orderExtra == null)
            {
                return NotFound();
            }

            _context.OrderExtras.Remove(orderExtra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExtraExists(int id)
        {
            return (_context.OrderExtras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
