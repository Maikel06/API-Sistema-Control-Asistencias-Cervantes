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
    public class Alumno_Asiste_BloqueHorarioController : ControllerBase
    {
        private readonly Context _context;

        public Alumno_Asiste_BloqueHorarioController(Context context)
        {
            _context = context;
        }

        // GET: api/Alumno_Asiste_BloqueHorario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumno_Asiste_BloqueHorario>>> GetAlumno_Asiste_BloquesHorario()
        {
            return await _context.Alumno_Asiste_BloquesHorario
                .Include(ab=>ab.Alumno)

                .Include(ab => ab.BloqueHorario)

                .ToListAsync();
        }

        // GET: api/Alumno_Asiste_BloqueHorario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno_Asiste_BloqueHorario>> GetAlumno_Asiste_BloqueHorario(int id)
        {
            var alumno_Asiste_BloqueHorario = await _context.Alumno_Asiste_BloquesHorario.FindAsync(id);

            if (alumno_Asiste_BloqueHorario == null)
            {
                return NotFound();
            }

            return alumno_Asiste_BloqueHorario;
        }

        // PUT: api/Alumno_Asiste_BloqueHorario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumno_Asiste_BloqueHorario(int id, Alumno_Asiste_BloqueHorario alumno_Asiste_BloqueHorario)
        {
            if (id != alumno_Asiste_BloqueHorario.AlumnoId)
            {
                return BadRequest();
            }

            _context.Entry(alumno_Asiste_BloqueHorario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Alumno_Asiste_BloqueHorarioExists(id))
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

        // POST: api/Alumno_Asiste_BloqueHorario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alumno_Asiste_BloqueHorario>> PostAlumno_Asiste_BloqueHorario(Alumno_Asiste_BloqueHorario alumno_Asiste_BloqueHorario)
        {
            _context.Alumno_Asiste_BloquesHorario.Add(alumno_Asiste_BloqueHorario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Alumno_Asiste_BloqueHorarioExists(alumno_Asiste_BloqueHorario.AlumnoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlumno_Asiste_BloqueHorario", new { id = alumno_Asiste_BloqueHorario.AlumnoId }, alumno_Asiste_BloqueHorario);
        }

        // DELETE: api/Alumno_Asiste_BloqueHorario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumno_Asiste_BloqueHorario(int id)
        {
            var alumno_Asiste_BloqueHorario = await _context.Alumno_Asiste_BloquesHorario.FindAsync(id);
            if (alumno_Asiste_BloqueHorario == null)
            {
                return NotFound();
            }

            _context.Alumno_Asiste_BloquesHorario.Remove(alumno_Asiste_BloqueHorario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Alumno_Asiste_BloqueHorarioExists(int id)
        {
            return _context.Alumno_Asiste_BloquesHorario.Any(e => e.AlumnoId == id);
        }
    }
}
