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
    [Route("api/Projets")]
    public class ProjetsController : Controller
    {
        private readonly MaderaContext _context;

        public ProjetsController(MaderaContext context)
        {
            _context = context;
        }

        // GET: api/Projets
        [HttpGet]
        public IEnumerable<Projet> GetProjet()
        {
            return _context.Projet;
        }

        // GET: api/Projets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projet = await _context.Projet.SingleOrDefaultAsync(m => m.Id == id);

            if (projet == null)
            {
                return NotFound();
            }

            return Ok(projet);
        }

        // PUT: api/Projets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjet([FromRoute] int id, [FromBody] Projet projet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projet.Id)
            {
                return BadRequest();
            }

            _context.Entry(projet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetExists(id))
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

        // POST: api/Projets
        [HttpPost]
        public async Task<IActionResult> PostProjet([FromBody] Projet projet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Projet.Add(projet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjet", new { id = projet.Id }, projet);
        }

        // DELETE: api/Projets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projet = await _context.Projet.SingleOrDefaultAsync(m => m.Id == id);
            if (projet == null)
            {
                return NotFound();
            }

            _context.Projet.Remove(projet);
            await _context.SaveChangesAsync();

            return Ok(projet);
        }

        private bool ProjetExists(int id)
        {
            return _context.Projet.Any(e => e.Id == id);
        }
    }
}