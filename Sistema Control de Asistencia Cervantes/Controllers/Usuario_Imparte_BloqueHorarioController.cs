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
    public class Usuario_Imparte_BloqueHorarioController : ControllerBase
    {
        private readonly Context _context;

        public Usuario_Imparte_BloqueHorarioController(Context context)
        {
            _context = context;
        }

        // GET: api/Usuario_Imparte_BloqueHorario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario_Imparte_BloqueHorario>>> GetUsuario_Imparte_BloquesHorario()
        {
            return await _context.Usuario_Imparte_BloquesHorario
                .Include(ub => ub.Usuario)

                .Include(ub => ub.BloqueHorario)

                .ToListAsync();
        }

        // GET: api/Usuario_Imparte_BloqueHorario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario_Imparte_BloqueHorario>> GetUsuario_Imparte_BloqueHorario(int id)
        {
            var usuario_Imparte_BloqueHorario = await _context.Usuario_Imparte_BloquesHorario.FindAsync(id);

            if (usuario_Imparte_BloqueHorario == null)
            {
                return NotFound();
            }

            return usuario_Imparte_BloqueHorario;
        }

        // PUT: api/Usuario_Imparte_BloqueHorario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario_Imparte_BloqueHorario(int id, Usuario_Imparte_BloqueHorario usuario_Imparte_BloqueHorario)
        {
            if (id != usuario_Imparte_BloqueHorario.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuario_Imparte_BloqueHorario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Usuario_Imparte_BloqueHorarioExists(id))
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

        // POST: api/Usuario_Imparte_BloqueHorario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario_Imparte_BloqueHorario>> PostUsuario_Imparte_BloqueHorario(Usuario_Imparte_BloqueHorario usuario_Imparte_BloqueHorario)
        {
            _context.Usuario_Imparte_BloquesHorario.Add(usuario_Imparte_BloqueHorario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Usuario_Imparte_BloqueHorarioExists(usuario_Imparte_BloqueHorario.UsuarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuario_Imparte_BloqueHorario", new { id = usuario_Imparte_BloqueHorario.UsuarioId }, usuario_Imparte_BloqueHorario);
        }

        // DELETE: api/Usuario_Imparte_BloqueHorario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario_Imparte_BloqueHorario(int id)
        {
            var usuario_Imparte_BloqueHorario = await _context.Usuario_Imparte_BloquesHorario.FindAsync(id);
            if (usuario_Imparte_BloqueHorario == null)
            {
                return NotFound();
            }

            _context.Usuario_Imparte_BloquesHorario.Remove(usuario_Imparte_BloqueHorario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Usuario_Imparte_BloqueHorarioExists(int id)
        {
            return _context.Usuario_Imparte_BloquesHorario.Any(e => e.UsuarioId == id);
        }
    }
}
