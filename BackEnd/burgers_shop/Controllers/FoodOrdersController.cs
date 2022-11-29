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
    public class FoodOrdersController : ControllerBase
    {
        private readonly BurgerShopContext _context;

        public FoodOrdersController(BurgerShopContext context)
        {
            _context = context;
        }

        // GET: api/FoodOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodOrder>>> GetFoodOrders()
        {
          if (_context.FoodOrders == null)
          {
              return NotFound();
          }
            return await _context.FoodOrders.ToListAsync();
        }

        // GET: api/FoodOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodOrder>> GetFoodOrder(int id)
        {
          if (_context.FoodOrders == null)
          {
              return NotFound();
          }
            var foodOrder = await _context.FoodOrders.FindAsync(id);

            if (foodOrder == null)
            {
                return NotFound();
            }

            return foodOrder;
        }

        // PUT: api/FoodOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodOrder(int id, FoodOrder foodOrder)
        {
            if (id != foodOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(foodOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodOrderExists(id))
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

        // POST: api/FoodOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodOrder>> PostFoodOrder(OrederContent orederContent)
        {
          if (_context.FoodOrders == null)
          {
              return Problem("Entity set 'BurgerShopContext.FoodOrders'  is null.");
          }
            FoodOrder foodOrder=new FoodOrder();
            OrderBurger orderBurger=new OrderBurger();
            OrderSide orderSide=new OrderSide();
            foodOrder.CustomerId=orederContent.customerId;
            await _context.FoodOrders.AddAsync(foodOrder);
            await _context.SaveChangesAsync();
            orderSide.OrderId=foodOrder.Id;
            orderBurger.OrderId=foodOrder.Id;
            orderBurger.BurgerId=orederContent.iOrderBurger.Id;
            // foreach (var item in orederContent?.iOrderSide)
            // {
                // orderSide.SideId=item.Id;
                // await _context.OrderSides.AddAsync(orderSide);
            // }
            await _context.OrderBurgers.AddAsync(orderBurger);
            
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetFoodOrder", new { id = orederContent.customerId }, orederContent);
        }

        // DELETE: api/FoodOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodOrder(int id)
        {
            if (_context.FoodOrders == null)
            {
                return NotFound();
            }
            var foodOrder = await _context.FoodOrders.FindAsync(id);
            if (foodOrder == null)
            {
                return NotFound();
            }

            _context.FoodOrders.Remove(foodOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodOrderExists(int id)
        {
            return (_context.FoodOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
