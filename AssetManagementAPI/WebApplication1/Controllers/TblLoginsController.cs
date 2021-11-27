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
    public class TblLoginsController : ControllerBase
    {
        private readonly AssetDBContext _context;

        public TblLoginsController(AssetDBContext context)
        {
            _context = context;
        }

        // GET: api/TblLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLogin>>> GetTblLogin()
        {
            return await _context.TblLogin.ToListAsync();
        }

        // GET: api/TblLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLogin>> GetTblLogin(int id)
        {
            var tblLogin = await _context.TblLogin.FindAsync(id);

            if (tblLogin == null)
            {
                return NotFound();
            }

            return tblLogin;
        }

        // PUT: api/TblLogins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLogin(int id, TblLogin tblLogin)
        {
            if (id != tblLogin.LId)
            {
                return BadRequest();
            }

            _context.Entry(tblLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLoginExists(id))
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

        // POST: api/TblLogins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblLogin>> PostTblLogin(TblLogin tblLogin)
        {
            _context.TblLogin.Add(tblLogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblLogin", new { id = tblLogin.LId }, tblLogin);
        }

        // DELETE: api/TblLogins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblLogin>> DeleteTblLogin(int id)
        {
            var tblLogin = await _context.TblLogin.FindAsync(id);
            if (tblLogin == null)
            {
                return NotFound();
            }

            _context.TblLogin.Remove(tblLogin);
            await _context.SaveChangesAsync();

            return tblLogin;
        }

        private bool TblLoginExists(int id)
        {
            return _context.TblLogin.Any(e => e.LId == id);
        }
    }
}
