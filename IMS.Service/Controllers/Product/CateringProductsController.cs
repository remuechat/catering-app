using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IMS.Domain.Entities.Meals.MealProduct;
using IMS.Service.Data;

namespace IMS.Service.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class CateringProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CateringProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CateringProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealProduct>>> GetUserMealProducts()
        {
            return await _context.UserMealProducts.ToListAsync();
        }

        // GET: api/CateringProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealProduct>> GetMealProduct(int id)
        {
            var mealProduct = await _context.UserMealProducts.FindAsync(id);

            if (mealProduct == null)
            {
                return NotFound();
            }

            return mealProduct;
        }

        // PUT: api/CateringProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealProduct(int id, MealProduct mealProduct)
        {
            if (id != mealProduct.MealProductID)
            {
                return BadRequest();
            }

            _context.Entry(mealProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealProductExists(id))
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

        // POST: api/CateringProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MealProduct>> PostMealProduct(MealProduct mealProduct)
        {
            _context.UserMealProducts.Add(mealProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMealProduct", new { id = mealProduct.MealProductID }, mealProduct);
        }

        // DELETE: api/CateringProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealProduct(int id)
        {
            var mealProduct = await _context.UserMealProducts.FindAsync(id);
            if (mealProduct == null)
            {
                return NotFound();
            }

            _context.UserMealProducts.Remove(mealProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MealProductExists(int id)
        {
            return _context.UserMealProducts.Any(e => e.MealProductID == id);
        }
    }
}
