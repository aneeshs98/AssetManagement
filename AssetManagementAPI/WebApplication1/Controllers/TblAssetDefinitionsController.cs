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
    public class TblAssetDefinitionsController : ControllerBase
    {
        private readonly AssetDBContext _context;

        public TblAssetDefinitionsController(AssetDBContext context)
        {
            _context = context;
        }

        // GET: api/TblAssetDefinitions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAssetDefinition>>> GetTblAssetDefinition()
        {
            return await _context.TblAssetDefinition.ToListAsync();
        }

        // GET: api/TblAssetDefinitions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAssetDefinition>> GetTblAssetDefinition(int id)
        {
            var tblAssetDefinition = await _context.TblAssetDefinition.FindAsync(id);

            if (tblAssetDefinition == null)
            {
                return NotFound();
            }

            return tblAssetDefinition;
        }

        // PUT: api/TblAssetDefinitions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAssetDefinition(int id, TblAssetDefinition tblAssetDefinition)
        {
            if (id != tblAssetDefinition.AdId)
            {
                return BadRequest();
            }

            _context.Entry(tblAssetDefinition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAssetDefinitionExists(id))
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

        // POST: api/TblAssetDefinitions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblAssetDefinition>> PostTblAssetDefinition(TblAssetDefinition tblAssetDefinition)
        {
            _context.TblAssetDefinition.Add(tblAssetDefinition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblAssetDefinition", new { id = tblAssetDefinition.AdId }, tblAssetDefinition);
        }

        // DELETE: api/TblAssetDefinitions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblAssetDefinition>> DeleteTblAssetDefinition(int id)
        {
            var tblAssetDefinition = await _context.TblAssetDefinition.FindAsync(id);
            if (tblAssetDefinition == null)
            {
                return NotFound();
            }

            _context.TblAssetDefinition.Remove(tblAssetDefinition);
            await _context.SaveChangesAsync();

            return tblAssetDefinition;
        }

        private bool TblAssetDefinitionExists(int id)
        {
            return _context.TblAssetDefinition.Any(e => e.AdId == id);
        }
    }
}
