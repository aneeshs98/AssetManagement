using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TblPurchaseOrdersController : ControllerBase
    {
        private readonly AssetDBContext _context;

        public TblPurchaseOrdersController(AssetDBContext context)
        {
            _context = context;
        }

        // GET: api/TblPurchaseOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPurchaseOrder>>> GetTblPurchaseOrder()
        {
            return await _context.TblPurchaseOrder.ToListAsync();
        }

        // GET: api/TblPurchaseOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPurchaseOrder>> GetTblPurchaseOrder(int id)
        {
            var tblPurchaseOrder = await _context.TblPurchaseOrder.FindAsync(id);

            if (tblPurchaseOrder == null)
            {
                return NotFound();
            }

            return tblPurchaseOrder;
        }

        // PUT: api/TblPurchaseOrders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPurchaseOrder(int id, TblPurchaseOrder tblPurchaseOrder)
        {
            if (id != tblPurchaseOrder.PdId)
            {
                return BadRequest();
            }

            _context.Entry(tblPurchaseOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPurchaseOrderExists(id))
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

        // POST: api/TblPurchaseOrders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblPurchaseOrder>> PostTblPurchaseOrder(TblPurchaseOrder tblPurchaseOrder)
        {
            _context.TblPurchaseOrder.Add(tblPurchaseOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPurchaseOrder", new { id = tblPurchaseOrder.PdId }, tblPurchaseOrder);
        }

        // DELETE: api/TblPurchaseOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblPurchaseOrder>> DeleteTblPurchaseOrder(int id)
        {
            var tblPurchaseOrder = await _context.TblPurchaseOrder.FindAsync(id);
            if (tblPurchaseOrder == null)
            {
                return NotFound();
            }

            _context.TblPurchaseOrder.Remove(tblPurchaseOrder);
            await _context.SaveChangesAsync();

            return tblPurchaseOrder;
        }

        private bool TblPurchaseOrderExists(int id)
        {
            return _context.TblPurchaseOrder.Any(e => e.PdId == id);
        }
    }
}
