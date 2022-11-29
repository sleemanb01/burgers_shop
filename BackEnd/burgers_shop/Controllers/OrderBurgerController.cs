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
    public class OrderBurgerController : ControllerBase
    {
        private readonly BurgerShopContext _context;

        public OrderBurgerController(BurgerShopContext context)
        {
            _context = context;
        }

        // GET: api/OrderBurger
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderBurger>>> GetOrderBurgers()
        {
          if (_context.OrderBurgers == null)
          {
              return NotFound();
          }
            return await _context.OrderBurgers.ToListAsync();
        }

        // GET: api/OrderBurger/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderBurger>> GetOrderBurger(int id)
        {
          if (_context.OrderBurgers == null)
          {
              return NotFound();
          }
            var orderBurger = await _context.OrderBurgers.FindAsync(id);

            if (orderBurger == null)
            {
                return NotFound();
            }

            return orderBurger;
        }

        // PUT: api/OrderBurger/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderBurger(int id, OrderBurger orderBurger)
        {
            if (id != orderBurger.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderBurger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderBurgerExists(id))
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

        // POST: api/OrderBurger
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderBurger>> PostOrderBurger(OrderBurger orderBurger)
        {
          if (_context.OrderBurgers == null)
          {
              return Problem("Entity set 'BurgerShopContext.OrderBurgers'  is null.");
          }
            _context.OrderBurgers.Add(orderBurger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderBurger", new { id = orderBurger.Id }, orderBurger);
        }

        // DELETE: api/OrderBurger/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderBurger(int id)
        {
            if (_context.OrderBurgers == null)
            {
                return NotFound();
            }
            var orderBurger = await _context.OrderBurgers.FindAsync(id);
            if (orderBurger == null)
            {
                return NotFound();
            }

            _context.OrderBurgers.Remove(orderBurger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderBurgerExists(int id)
        {
            return (_context.OrderBurgers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
