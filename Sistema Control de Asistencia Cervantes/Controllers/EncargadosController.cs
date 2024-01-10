﻿using System;
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
    public class EncargadosController : ControllerBase
    {
        private readonly Context _context;
        private bool continuar = true;

        public EncargadosController(Context context)
        {
            _context = context;
        }

        [HttpGet("ComprobarEncargado")]
        public async Task<ActionResult<IEnumerable<Alumno>>> ComprobarEncargado(Encargado encargado)
        {
            List<Encargado> alumnos = await _context.Encargado.ToListAsync();

            foreach (Encargado aux in alumnos)
            {
                if (aux.Cedula == encargado.Cedula)
                {
                    this.continuar = false;
                    break;
                }
            }

            return Ok(alumnos);
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<Encargado>> PostEncargado(Encargado encargado)
        {
            await this.ComprobarEncargado(encargado);
            if (this.continuar)
            {
                _context.Encargado.Add(encargado);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEncargado", new { id = encargado.Id }, encargado);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpGet("ListaEncargados")]
        public async Task<ActionResult<IEnumerable<Encargado>>> listaEncargados()
        {
            return await _context.Encargado.ToListAsync();
        }

        // GET: api/Encargados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encargado>>> GetEncargado()
        {
            return await _context.Encargado
                .Include(e => e.Encargado_Cargo_Alumnos)
                .ThenInclude(ea => ea.Alumno)
                .ToListAsync();
        }

        // GET: api/Encargados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Encargado>> GetEncargado(int id)
        {
            var encargado = await _context.Encargado.FindAsync(id);

            if (encargado == null)
            {
                return NotFound();
            }

            return encargado;
        }

        // PUT: api/Encargados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEncargado(int id, Encargado encargado)
        {
            if (id != encargado.Id)
            {
                return BadRequest();
            }

            _context.Entry(encargado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncargadoExists(id))
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

        // POST: api/Encargados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Encargado>> PostEncargado(Encargado encargado)
        //{
        //    _context.Encargado.Add(encargado);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetEncargado", new { id = encargado.Id }, encargado);
        //}

        // DELETE: api/Encargados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncargado(int id)
        {
            var encargado = await _context.Encargado.FindAsync(id);
            if (encargado == null)
            {
                return NotFound();
            }

            _context.Encargado.Remove(encargado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EncargadoExists(int id)
        {
            return _context.Encargado.Any(e => e.Id == id);
        }
    }
}
