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
    public class Usuario_Imparte_CursoController : ControllerBase
    {
        private readonly Context _context;

        public Usuario_Imparte_CursoController(Context context)
        {
            _context = context;
        }

        // GET: api/Usuario_Imparte_Curso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario_Imparte_Curso>>> GetUsuario_Imparte_Curso()
        {
            return await _context.Usuario_Imparte_Curso
                .Include(uc => uc.Usuario)

                .Include(uc => uc.Curso)

                .ToListAsync();
        }

        // GET: api/Usuario_Imparte_Curso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario_Imparte_Curso>> GetUsuario_Imparte_Curso(int id)
        {
            var usuario_Imparte_Curso = await _context.Usuario_Imparte_Curso.FindAsync(id);

            if (usuario_Imparte_Curso == null)
            {
                return NotFound();
            }

            return usuario_Imparte_Curso;
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<Usuario_Imparte_Curso>> PostCurso(Usuario_Imparte_Curso usuario_Imparte_Curso)
        {
            _context.Usuario_Imparte_Curso.Add(usuario_Imparte_Curso);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUsuario_Imparte_Curso", new { id = usuario_Imparte_Curso.CursoId }, usuario_Imparte_Curso);
        }

        [HttpGet("ListaImparte")]
        public async Task<ActionResult<IEnumerable<Usuario_Imparte_Curso>>> listaImparte()
        {
            return await _context.Usuario_Imparte_Curso.ToListAsync();
        }

        // PUT: api/Usuario_Imparte_Curso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario_Imparte_Curso(int id, Usuario_Imparte_Curso usuario_Imparte_Curso)
        {
            if (id != usuario_Imparte_Curso.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuario_Imparte_Curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Usuario_Imparte_CursoExists(id))
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


        // POST: api/Usuario_Imparte_Curso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario_Imparte_Curso>> PostUsuario_Imparte_Curso(Usuario_Imparte_Curso usuario_Imparte_Curso)
        {
            _context.Usuario_Imparte_Curso.Add(usuario_Imparte_Curso);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Usuario_Imparte_CursoExists(usuario_Imparte_Curso.UsuarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuario_Imparte_Curso", new { id = usuario_Imparte_Curso.UsuarioId }, usuario_Imparte_Curso);
        }

        [HttpDelete("{usuarioId}/{cursoId}")]
        public async Task<IActionResult> DeleteEncargado_Cargo_Alumno(int usuarioId, int cursoId)
        {
            var usuario_Imparte_Curso = await _context.Usuario_Imparte_Curso.FindAsync(usuarioId, cursoId);
            if (usuario_Imparte_Curso == null)
            {
                return NotFound();
            }

            _context.Usuario_Imparte_Curso.Remove(usuario_Imparte_Curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Usuario_Imparte_CursoExists(int id)
        {
            return _context.Usuario_Imparte_Curso.Any(e => e.UsuarioId == id);
        }
    }
}
