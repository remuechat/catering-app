using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IMS.Service.Data;
using IMS.Domain.Models.Packages;

namespace IMS.Service.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class MealPackagesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MealPackagesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/admin/MealPackages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealPackage>>> GetMealPackages()
        {
            return await _context.MealPackages.ToListAsync();
        }

        // GET: api/admin/MealPackages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealPackage>> GetMealPackage(int id)
        {
            var mealPackage = await _context.MealPackages.FindAsync(id);

            if (mealPackage == null)
            {
                return NotFound();
            }

            return mealPackage;
        }

        // PUT: api/admin/MealPackages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealPackage(int id, MealPackage mealPackage)
        {
            if (id != mealPackage.MealPackageId)
            {
                return BadRequest();
            }

            _context.Entry(mealPackage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealPackageExists(id))
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

        // POST: api/admin/MealPackages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MealPackage>> PostMealPackage(MealPackage mealPackage)
        {
            _context.MealPackages.Add(mealPackage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMealPackage", new { id = mealPackage.MealPackageId }, mealPackage);
        }

        // DELETE: api/admin/MealPackages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealPackage(int id)
        {
            var mealPackage = await _context.MealPackages.FindAsync(id);
            if (mealPackage == null)
            {
                return NotFound();
            }

            _context.MealPackages.Remove(mealPackage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MealPackageExists(int id)
        {
            return _context.MealPackages.Any(e => e.MealPackageId == id);
        }
    }
}
