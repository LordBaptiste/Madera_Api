using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Madera.Model.Models;

namespace Madera.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Devis")]
    public class DevisController : Controller
    {
        private readonly MaderaContext _context;

        public DevisController(MaderaContext context)
        {
            _context = context;
        }

        // GET: api/Devis
        [HttpGet]
        public IEnumerable<Devis> GetDevis()
        {
            return _context.Devis;
        }

        // GET: api/Devis/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevis([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var devis = await _context.Devis.SingleOrDefaultAsync(m => m.Id == id);

            if (devis == null)
            {
                return NotFound();
            }

            return Ok(devis);
        }

        // PUT: api/Devis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevis([FromRoute] int id, [FromBody] Devis devis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != devis.Id)
            {
                return BadRequest();
            }

            _context.Entry(devis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevisExists(id))
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

        // POST: api/Devis
        [HttpPost]
        public async Task<IActionResult> PostDevis([FromBody] Devis devis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Devis.Add(devis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevis", new { id = devis.Id }, devis);
        }

        // DELETE: api/Devis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevis([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var devis = await _context.Devis.SingleOrDefaultAsync(m => m.Id == id);
            if (devis == null)
            {
                return NotFound();
            }

            _context.Devis.Remove(devis);
            await _context.SaveChangesAsync();

            return Ok(devis);
        }

        private bool DevisExists(int id)
        {
            return _context.Devis.Any(e => e.Id == id);
        }
    }
}