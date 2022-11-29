using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurgersShop.Models;
using System.Data.SqlClient;
using System.Data;

namespace BurgersShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly BurgerShopContext _context;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(BurgerShopContext context,
                                        ILogger<CustomersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            return await _context.Customers.ToListAsync();
        }

        // // GET: api/Customers/custGet
        //
        [HttpGet("custGet")]
        public async Task<ActionResult<IEnumerable<Customer>>> custGet()
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            
            return getCustomerList();
        }

        List<Customer> getCustomerList()
        {
            
            List<Customer> getAllList = new List<Customer>();
            using (SqlConnection con = new SqlConnection("Server=localhost;Database=BurgerShop;Trusted_Connection=False;password=1234;user=sa1;"))
            {
                using (SqlCommand cmd = new SqlCommand("getCustomers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    

                    while (dr.Read())
                    {
                        // _logger.LogError(dr.GetDataTypeName(5) + " " + dr.GetString(5));
                        getAllList.Add(new Customer
                        {
                            Id = dr.GetInt32(0),
                            Fname = dr.GetString(1),
                            Lname = dr.GetString(2),
                            Phone = dr.GetString(3),
                            Email = dr.GetString(4),
                            Bdate = dr.GetDateTime(5)
                        });
                    }
                }
            }
            return getAllList;
        }

        // stop navigation
        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Customer>> GetCustomerName(string name)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(name);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'BurgerShopContext.Customers'  is null.");
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
