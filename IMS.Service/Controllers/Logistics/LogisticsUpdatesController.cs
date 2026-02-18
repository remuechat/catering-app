using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IMS.Domain.Entities.Logistics;
using IMS.Service.Data;

namespace IMS.Service.Controllers.Logistics
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogisticsUpdatesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LogisticsUpdatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LogisticsUpdates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogisticsUpdate>>> GetLogisticsUpdates()
        {
            return await _context.LogisticsUpdates.ToListAsync();
        }

        // GET: api/LogisticsUpdates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogisticsUpdate>> GetLogisticsUpdate(int id)
        {
            var logisticsUpdate = await _context.LogisticsUpdates.FindAsync(id);

            if (logisticsUpdate == null)
            {
                return NotFound();
            }

            return logisticsUpdate;
        }

        // PUT: api/LogisticsUpdates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogisticsUpdate(int id, LogisticsUpdate logisticsUpdate)
        {
            if (id != logisticsUpdate.DeliveryUpdateID)
            {
                return BadRequest();
            }

            _context.Entry(logisticsUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogisticsUpdateExists(id))
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

        // POST: api/LogisticsUpdates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogisticsUpdate>> PostLogisticsUpdate(LogisticsUpdate logisticsUpdate)
        {
            _context.LogisticsUpdates.Add(logisticsUpdate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogisticsUpdate", new { id = logisticsUpdate.DeliveryUpdateID }, logisticsUpdate);
        }

        // DELETE: api/LogisticsUpdates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogisticsUpdate(int id)
        {
            var logisticsUpdate = await _context.LogisticsUpdates.FindAsync(id);
            if (logisticsUpdate == null)
            {
                return NotFound();
            }

            _context.LogisticsUpdates.Remove(logisticsUpdate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogisticsUpdateExists(int id)
        {
            return _context.LogisticsUpdates.Any(e => e.DeliveryUpdateID == id);
        }
    }
}
