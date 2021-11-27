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
    public class TblAssetMastersController : ControllerBase
    {
        private readonly AssetDBContext _context;

        public TblAssetMastersController(AssetDBContext context)
        {
            _context = context;
        }

        // GET: api/TblAssetMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAssetMaster>>> GetTblAssetMaster()
        {
            return await _context.TblAssetMaster.ToListAsync();
        }

        // GET: api/TblAssetMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAssetMaster>> GetTblAssetMaster(int id)
        {
            var tblAssetMaster = await _context.TblAssetMaster.FindAsync(id);

            if (tblAssetMaster == null)
            {
                return NotFound();
            }

            return tblAssetMaster;
        }

        // PUT: api/TblAssetMasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAssetMaster(int id, TblAssetMaster tblAssetMaster)
        {
            if (id != tblAssetMaster.AmId)
            {
                return BadRequest();
            }

            _context.Entry(tblAssetMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAssetMasterExists(id))
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

        // POST: api/TblAssetMasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblAssetMaster>> PostTblAssetMaster(TblAssetMaster tblAssetMaster)
        {
            _context.TblAssetMaster.Add(tblAssetMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblAssetMaster", new { id = tblAssetMaster.AmId }, tblAssetMaster);
        }

        // DELETE: api/TblAssetMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblAssetMaster>> DeleteTblAssetMaster(int id)
        {
            var tblAssetMaster = await _context.TblAssetMaster.FindAsync(id);
            if (tblAssetMaster == null)
            {
                return NotFound();
            }

            _context.TblAssetMaster.Remove(tblAssetMaster);
            await _context.SaveChangesAsync();

            return tblAssetMaster;
        }

        private bool TblAssetMasterExists(int id)
        {
            return _context.TblAssetMaster.Any(e => e.AmId == id);
        }
    }
}
