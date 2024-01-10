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
    public class Encargado_Cargo_AlumnoController : ControllerBase
    {
        private readonly Context _context;

        public Encargado_Cargo_AlumnoController(Context context)
        {
            _context = context;
        }

        // GET: api/Encargado_Cargo_Alumno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encargado_Cargo_Alumno>>> GetEncargado_Cargo_Alumno()
        {
            return await _context.Encargado_Cargo_Alumno
                .Include(ea => ea.Alumno)
                .Include(ea => ea.Encargado)
                .ToListAsync();
        }

        // GET: api/Encargado_Cargo_Alumno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Encargado_Cargo_Alumno>> GetEncargado_Cargo_Alumno(int id)
        {
            var encargado_Cargo_Alumno = await _context.Encargado_Cargo_Alumno.FindAsync(id);

            if (encargado_Cargo_Alumno == null)
            {
                return NotFound();
            }

            return encargado_Cargo_Alumno;
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<Encargado_Cargo_Alumno>> PostCurso(Encargado_Cargo_Alumno encargado_Cargo_Alumno)
        {
            _context.Encargado_Cargo_Alumno.Add(encargado_Cargo_Alumno);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEncargado_Cargo_Alumno", new { id = encargado_Cargo_Alumno.AlumnoId }, encargado_Cargo_Alumno);
        }

        [HttpGet("ListaCargos")]
        public async Task<ActionResult<IEnumerable<Encargado_Cargo_Alumno>>> listaCargos()
        {
            return await _context.Encargado_Cargo_Alumno.ToListAsync();
        }

        // POST: api/Encargado_Cargo_Alumno
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Encargado_Cargo_Alumno>> PostEncargado_Cargo_Alumno(Encargado_Cargo_Alumno encargado_Cargo_Alumno)
        {
            _context.Encargado_Cargo_Alumno.Add(encargado_Cargo_Alumno);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Encargado_Cargo_AlumnoExists(encargado_Cargo_Alumno.EncargadoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEncargado_Cargo_Alumno", new { id = encargado_Cargo_Alumno.EncargadoId }, encargado_Cargo_Alumno);
        }

        [HttpDelete("{encargadoId}/{alumnoId}")]
        public async Task<IActionResult> DeleteEncargado_Cargo_Alumno(int encargadoId, int alumnoId)
        {
            var encargado_Cargo_Alumno = await _context.Encargado_Cargo_Alumno.FindAsync(encargadoId,alumnoId);
            if (encargado_Cargo_Alumno == null)
            {
                return NotFound();
            }

            _context.Encargado_Cargo_Alumno.Remove(encargado_Cargo_Alumno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Encargado_Cargo_AlumnoExists(int id)
        {
            return _context.Encargado_Cargo_Alumno.Any(e => e.AlumnoId == id);
        }
    }
}
