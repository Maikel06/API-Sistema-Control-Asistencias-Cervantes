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
    public class AlumnosController : ControllerBase
    {
        private readonly Context _context;
        private bool continuar=true;

        public AlumnosController(Context context)
        {
            _context = context;
        }

        // GET: api/Alumnos
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumno()
        //{
        //    return await _context.Alumno
        //        .Include(a => a.Alumno_Inscribe_Cursos)
        //        .ThenInclude(ac => ac.Curso)

        //        .Include(a => a.Encargado_Cargo_Alumnos)
        //        .ThenInclude(ea => ea.Encargado)

        //        .Include(a => a.Alumno_Asiste_BloqueHorarios)
        //        .ThenInclude(ab => ab.BloqueHorario)

        //        .ToListAsync();
        //}
        [HttpGet("ComprobarAlumno")]
        public async Task<ActionResult<IEnumerable<Alumno>>> ComprobarAlumno(Alumno alumno)
        {
            List<Alumno> alumnos = await _context.Alumno.ToListAsync();

            foreach (Alumno aux in alumnos)
            {
                if (aux.Cedula == alumno.Cedula)
                {
                    this.continuar = false;
                    break;
                }
            }

            return Ok(alumnos);
        }

        [HttpGet("ListaEstudiantes")]
        public async Task<ActionResult<IEnumerable<Alumno>>> listaEstudiantes()
        {
            return await _context.Alumno.ToListAsync();
        }


        // GET: api/Alumnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno>> GetAlumno(int id)
        {
            var alumno = await _context.Alumno.FindAsync(id);

            if (alumno == null)
            {
                return NotFound();
            }

            return alumno;
        }

        // PUT: api/Alumnos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumno(int id, Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }

            _context.Entry(alumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoExists(id))
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

        // POST: api/Alumnos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Registrar")]
        public async Task<ActionResult<Alumno>> PostAlumno(Alumno alumno)
        {
            await this.ComprobarAlumno(alumno);
            if (this.continuar)
            {
                _context.Alumno.Add(alumno);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAlumno", new { id = alumno.Id }, alumno);
            }
            else
            {
                return Ok(false);
            }
        }

        // DELETE: api/Alumnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumno(int id)
        {
            Console.WriteLine("en delete");
            var alumno = await _context.Alumno.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }

            _context.Alumno.Remove(alumno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlumnoExists(int id)
        {
            return _context.Alumno.Any(e => e.Id == id);
        }
    }
}
