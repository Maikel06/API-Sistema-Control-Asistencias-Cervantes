using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Control_de_Asistencia_Cervantes.Dominio;

namespace Sistema_Control_de_Asistencia_Cervantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloquesHorarioController : ControllerBase
    {
        private readonly Context _context;

        public BloquesHorarioController(Context context)
        {
            _context = context;
        }

        // GET: api/BloquesHorario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BloqueHorario>>> GetBloqueHorario()
        {
            return await _context.BloqueHorario.ToListAsync();
        }

        // GET: api/BloquesHorario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BloqueHorario>> GetBloqueHorario(int id)
        {
            var bloqueHorario = await _context.BloqueHorario.FindAsync(id);

            if (bloqueHorario == null)
            {
                return NotFound();
            }

            return bloqueHorario;
        }

        // PUT: api/BloquesHorario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloqueHorario(int id, BloqueHorario bloqueHorario)
        {
            if (id != bloqueHorario.Id)
            {
                return BadRequest();
            }

            _context.Entry(bloqueHorario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloqueHorarioExists(id))
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

        // POST: api/BloquesHorario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BloqueHorario>> PostBloqueHorario(BloqueHorario bloqueHorario)
        {
            _context.BloqueHorario.Add(bloqueHorario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBloqueHorario", new { id = bloqueHorario.Id }, bloqueHorario);
        }

        // DELETE: api/BloquesHorario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBloqueHorario(int id)
        {
            var bloqueHorario = await _context.BloqueHorario.FindAsync(id);
            if (bloqueHorario == null)
            {
                return NotFound();
            }

            _context.BloqueHorario.Remove(bloqueHorario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BloqueHorarioExists(int id)
        {
            return _context.BloqueHorario.Any(e => e.Id == id);
        }
    }
}
