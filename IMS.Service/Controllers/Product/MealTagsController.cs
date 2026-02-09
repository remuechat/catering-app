using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IMS.Domain.Models.Meals.MealItems;
using IMS.Service.Data;

namespace IMS.Service.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealTagsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MealTagsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MealTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealTag>>> GetMealTags()
        {
            return await _context.MealTags.ToListAsync();
        }

        // GET: api/MealTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealTag>> GetMealTag(int id)
        {
            var mealTag = await _context.MealTags.FindAsync(id);

            if (mealTag == null)
            {
                return NotFound();
            }

            return mealTag;
        }

        // PUT: api/MealTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealTag(int id, MealTag mealTag)
        {
            if (id != mealTag.MealTagID)
            {
                return BadRequest();
            }

            _context.Entry(mealTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealTagExists(id))
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

        // POST: api/MealTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MealTag>> PostMealTag(MealTag mealTag)
        {
            _context.MealTags.Add(mealTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMealTag", new { id = mealTag.MealTagID }, mealTag);
        }

        // DELETE: api/MealTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealTag(int id)
        {
            var mealTag = await _context.MealTags.FindAsync(id);
            if (mealTag == null)
            {
                return NotFound();
            }

            _context.MealTags.Remove(mealTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MealTagExists(int id)
        {
            return _context.MealTags.Any(e => e.MealTagID == id);
        }
    }
}
