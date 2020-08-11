using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EquipAPI.Data;
using EquipsLibrary;
using Microsoft.AspNetCore.Cors;

namespace EquipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ApiPolicy")]
    public class EquipsController : ControllerBase
    {
        private readonly EquipDbContext _context;

        public EquipsController(EquipDbContext context)
        {
            _context = context;
        }

        // GET: api/Equips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equips>>> GetEquips()
        {
            return await _context.Equips.ToListAsync();
        }

        // GET: api/Equips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equips>> GetEquips(string id)
        {
            var equips = await _context.Equips.FindAsync(id);

            if (equips == null)
            {
                return NotFound();
            }

            return equips;
        }

        // PUT: api/Equips/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquips(string id, Equips equips)
        {
            if (id != equips.EquipsId)
            {
                return BadRequest();
            }

            _context.Entry(equips).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipsExists(id))
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

        // POST: api/Equips
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Equips>> PostEquips(Equips equips)
        {
            _context.Equips.Add(equips);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipsExists(equips.EquipsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquips", new { id = equips.EquipsId }, equips);
        }

        // DELETE: api/Equips/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Equips>> DeleteEquips(string id)
        {
            var equips = await _context.Equips.FindAsync(id);
            if (equips == null)
            {
                return NotFound();
            }

            _context.Equips.Remove(equips);
            await _context.SaveChangesAsync();

            return equips;
        }

        private bool EquipsExists(string id)
        {
            return _context.Equips.Any(e => e.EquipsId == id);
        }
    }
}
