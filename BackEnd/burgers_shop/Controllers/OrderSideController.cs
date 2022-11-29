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
    public class OrderSideController : ControllerBase
    {
        private readonly BurgerShopContext _context;

        public OrderSideController(BurgerShopContext context)
        {
            _context = context;
        }

        // GET: api/OrderSide
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderSide>>> GetOrderSides()
        {
          if (_context.OrderSides == null)
          {
              return NotFound();
          }
            return await _context.OrderSides.ToListAsync();
        }

        // GET: api/OrderSide/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderSide>> GetOrderSide(int id)
        {
          if (_context.OrderSides == null)
          {
              return NotFound();
          }
            var orderSide = await _context.OrderSides.FindAsync(id);

            if (orderSide == null)
            {
                return NotFound();
            }

            return orderSide;
        }

        // PUT: api/OrderSide/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderSide(int id, OrderSide orderSide)
        {
            if (id != orderSide.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderSide).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderSideExists(id))
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

        // POST: api/OrderSide
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderSide>> PostOrderSide(OrderSide orderSide)
        {
          if (_context.OrderSides == null)
          {
              return Problem("Entity set 'BurgerShopContext.OrderSides'  is null.");
          }
            _context.OrderSides.Add(orderSide);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderSide", new { id = orderSide.Id }, orderSide);
        }

        // DELETE: api/OrderSide/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderSide(int id)
        {
            if (_context.OrderSides == null)
            {
                return NotFound();
            }
            var orderSide = await _context.OrderSides.FindAsync(id);
            if (orderSide == null)
            {
                return NotFound();
            }

            _context.OrderSides.Remove(orderSide);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderSideExists(int id)
        {
            return (_context.OrderSides?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
