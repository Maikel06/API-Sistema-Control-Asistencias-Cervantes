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
    public class Alumno_Inscribe_CursoController : ControllerBase
    {
        private readonly Context _context;

        public Alumno_Inscribe_CursoController(Context context)
        {
            _context = context;
        }

        // GET: api/Alumno_Inscribe_Curso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumno_Inscribe_Curso>>> GetAlumno_Inscribe_Curso()
        {
            return await _context.Alumno_Inscribe_Curso
                .Include(ac=>ac.Alumno)

                .Include(ac => ac.Curso)

                .ToListAsync();
        }

        // GET: api/Alumno_Inscribe_Curso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno_Inscribe_Curso>> GetAlumno_Inscribe_Curso(int id)
        {
            var alumno_Inscribe_Curso = await _context.Alumno_Inscribe_Curso.FindAsync(id);

            if (alumno_Inscribe_Curso == null)
            {
                return NotFound();
            }

            return alumno_Inscribe_Curso;
        }

        // PUT: api/Alumno_Inscribe_Curso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumno_Inscribe_Curso(int id, Alumno_Inscribe_Curso alumno_Inscribe_Curso)
        {
            if (id != alumno_Inscribe_Curso.AlumnoId)
            {
                return BadRequest();
            }

            _context.Entry(alumno_Inscribe_Curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Alumno_Inscribe_CursoExists(id))
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

        // POST: api/Alumno_Inscribe_Curso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alumno_Inscribe_Curso>> PostAlumno_Inscribe_Curso(Alumno_Inscribe_Curso alumno_Inscribe_Curso)
        {
            _context.Alumno_Inscribe_Curso.Add(alumno_Inscribe_Curso);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Alumno_Inscribe_CursoExists(alumno_Inscribe_Curso.AlumnoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlumno_Inscribe_Curso", new { id = alumno_Inscribe_Curso.AlumnoId }, alumno_Inscribe_Curso);
        }

        // DELETE: api/Alumno_Inscribe_Curso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumno_Inscribe_Curso(int id)
        {
            var alumno_Inscribe_Curso = await _context.Alumno_Inscribe_Curso.FindAsync(id);
            if (alumno_Inscribe_Curso == null)
            {
                return NotFound();
            }

            _context.Alumno_Inscribe_Curso.Remove(alumno_Inscribe_Curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Alumno_Inscribe_CursoExists(int id)
        {
            return _context.Alumno_Inscribe_Curso.Any(e => e.AlumnoId == id);
        }
    }
}
