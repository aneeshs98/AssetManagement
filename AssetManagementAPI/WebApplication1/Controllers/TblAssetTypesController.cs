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
    public class TblAssetTypesController : ControllerBase
    {
        private readonly AssetDBContext _context;

        public TblAssetTypesController(AssetDBContext context)
        {
            _context = context;
        }

        // GET: api/TblAssetTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAssetType>>> GetTblAssetType()
        {
            return await _context.TblAssetType.ToListAsync();
        }

        // GET: api/TblAssetTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAssetType>> GetTblAssetType(int id)
        {
            var tblAssetType = await _context.TblAssetType.FindAsync(id);

            if (tblAssetType == null)
            {
                return NotFound();
            }

            return tblAssetType;
        }

        // PUT: api/TblAssetTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAssetType(int id, TblAssetType tblAssetType)
        {
            if (id != tblAssetType.AtId)
            {
                return BadRequest();
            }

            _context.Entry(tblAssetType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAssetTypeExists(id))
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

        // POST: api/TblAssetTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblAssetType>> PostTblAssetType(TblAssetType tblAssetType)
        {
            _context.TblAssetType.Add(tblAssetType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblAssetType", new { id = tblAssetType.AtId }, tblAssetType);
        }

        // DELETE: api/TblAssetTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblAssetType>> DeleteTblAssetType(int id)
        {
            var tblAssetType = await _context.TblAssetType.FindAsync(id);
            if (tblAssetType == null)
            {
                return NotFound();
            }

            _context.TblAssetType.Remove(tblAssetType);
            await _context.SaveChangesAsync();

            return tblAssetType;
        }

        private bool TblAssetTypeExists(int id)
        {
            return _context.TblAssetType.Any(e => e.AtId == id);
        }
    }
}
