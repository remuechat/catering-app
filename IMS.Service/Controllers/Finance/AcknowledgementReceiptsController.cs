using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IMS.Domain.Models.Financial.Receipt;
using IMS.Service.Data;

namespace IMS.Service.Controllers.Finance
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcknowledgementReceiptsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AcknowledgementReceiptsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AcknowledgementReceipts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcknowledgementReceipt>>> GetAcknowledgementReceipts()
        {
            return await _context.AcknowledgementReceipts.ToListAsync();
        }

        // GET: api/AcknowledgementReceipts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcknowledgementReceipt>> GetAcknowledgementReceipt(int id)
        {
            var acknowledgementReceipt = await _context.AcknowledgementReceipts.FindAsync(id);

            if (acknowledgementReceipt == null)
            {
                return NotFound();
            }

            return acknowledgementReceipt;
        }

        // PUT: api/AcknowledgementReceipts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcknowledgementReceipt(int id, AcknowledgementReceipt acknowledgementReceipt)
        {
            if (id != acknowledgementReceipt.AcknowledgementReceiptID)
            {
                return BadRequest();
            }

            _context.Entry(acknowledgementReceipt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcknowledgementReceiptExists(id))
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

        // POST: api/AcknowledgementReceipts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AcknowledgementReceipt>> PostAcknowledgementReceipt(AcknowledgementReceipt acknowledgementReceipt)
        {
            _context.AcknowledgementReceipts.Add(acknowledgementReceipt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcknowledgementReceipt", new { id = acknowledgementReceipt.AcknowledgementReceiptID }, acknowledgementReceipt);
        }

        // DELETE: api/AcknowledgementReceipts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcknowledgementReceipt(int id)
        {
            var acknowledgementReceipt = await _context.AcknowledgementReceipts.FindAsync(id);
            if (acknowledgementReceipt == null)
            {
                return NotFound();
            }

            _context.AcknowledgementReceipts.Remove(acknowledgementReceipt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcknowledgementReceiptExists(int id)
        {
            return _context.AcknowledgementReceipts.Any(e => e.AcknowledgementReceiptID == id);
        }
    }
}
