using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblVendorsController : ControllerBase
    {
        private readonly AssetDBContext _context;

        public TblVendorsController(AssetDBContext context)
        {
            _context = context;
        }

        // GET: api/TblVendors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblVendor>>> GetTblVendor()
        {
            return await _context.TblVendor.ToListAsync();
        }

        // GET: api/TblVendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblVendor>> GetTblVendor(int id)
        {
            var tblVendor = await _context.TblVendor.FindAsync(id);

            if (tblVendor == null)
            {
                return NotFound();
            }

            return tblVendor;
        }

        // PUT: api/TblVendors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblVendor(int id, TblVendor tblVendor)
        {
            if (id != tblVendor.VdId)
            {
                return BadRequest();
            }

            _context.Entry(tblVendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblVendorExists(id))
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

        // POST: api/TblVendors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblVendor>> PostTblVendor(TblVendor tblVendor)
        {
            _context.TblVendor.Add(tblVendor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblVendor", new { id = tblVendor.VdId }, tblVendor);
        }

        // DELETE: api/TblVendors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblVendor>> DeleteTblVendor(int id)
        {
            var tblVendor = await _context.TblVendor.FindAsync(id);
            if (tblVendor == null)
            {
                return NotFound();
            }

            _context.TblVendor.Remove(tblVendor);
            await _context.SaveChangesAsync();

            return tblVendor;
        }

        private bool TblVendorExists(int id)
        {
            return _context.TblVendor.Any(e => e.VdId == id);
        }
    }
}
