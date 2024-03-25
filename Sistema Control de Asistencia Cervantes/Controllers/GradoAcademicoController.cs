
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Control_de_Asistencia_Cervantes.Dominio;

namespace Sistema_Control_de_Asistencia_Cervantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradoAcademicoController : ControllerBase
    {
        private readonly Context _context;

        public GradoAcademicoController(Context context)
        {
            _context = context;
        }

        // GET: api/GradoAcademico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradoAcademico>>> GetGradoAcademico()
        {
            return await _context.GradoAcademico.ToListAsync();


        }


        // GET: api/GradoAcademico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GradoAcademico>> GetGradoById(int id)
        {
            var grado = await _context.GradoAcademico.FindAsync(id);

            if (grado == null)
            {
                return NotFound();
            }

            return grado;
        }


        // PUT: api/GradoAcademico/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGradoAcademico(int id, GradoAcademico grado)
        {
            if (id != grado.Id)
            {
                return BadRequest();
            }

            _context.Entry(grado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradoExists(id))
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


        // POST: api/GradoAcademico
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Registrar")]
        public async Task<ActionResult<GradoAcademico>> PostGradoAcademico(GradoAcademico grado)
        {
            _context.GradoAcademico.Add(grado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGradoById", new { id = grado.Id }, grado);
        }




        // DELETE: api/GradoAcademico/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGradoAcademico(int id)
        {
            var grado = await _context.GradoAcademico.FindAsync(id);
            if (grado == null)
            {
                return NotFound();
            }

            _context.GradoAcademico.Remove(grado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradoExists(int id)
        {
            return _context.GradoAcademico.Any(e => e.Id == id);
        }
    }
}
