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
    public class TblUserRegistrationsController : ControllerBase
    {
        private readonly AssetDBContext _context;

        public TblUserRegistrationsController(AssetDBContext context)
        {
            _context = context;
        }

        // GET: api/TblUserRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUserRegistration>>> GetTblUserRegistration()
        {
            return await _context.TblUserRegistration.ToListAsync();
        }

        // GET: api/TblUserRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUserRegistration>> GetTblUserRegistration(int id)
        {
            var tblUserRegistration = await _context.TblUserRegistration.FindAsync(id);

            if (tblUserRegistration == null)
            {
                return NotFound();
            }

            return tblUserRegistration;
        }

        // PUT: api/TblUserRegistrations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUserRegistration(int id, TblUserRegistration tblUserRegistration)
        {
            if (id != tblUserRegistration.UId)
            {
                return BadRequest();
            }

            _context.Entry(tblUserRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUserRegistrationExists(id))
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

        // POST: api/TblUserRegistrations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblUserRegistration>> PostTblUserRegistration(TblUserRegistration tblUserRegistration)
        {
            _context.TblUserRegistration.Add(tblUserRegistration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUserRegistration", new { id = tblUserRegistration.UId }, tblUserRegistration);
        }

        // DELETE: api/TblUserRegistrations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblUserRegistration>> DeleteTblUserRegistration(int id)
        {
            var tblUserRegistration = await _context.TblUserRegistration.FindAsync(id);
            if (tblUserRegistration == null)
            {
                return NotFound();
            }

            _context.TblUserRegistration.Remove(tblUserRegistration);
            await _context.SaveChangesAsync();

            return tblUserRegistration;
        }

        private bool TblUserRegistrationExists(int id)
        {
            return _context.TblUserRegistration.Any(e => e.UId == id);
        }
    }
}
