using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAlkemyPI;
using ApiAlkemyPI.Models;

namespace ApiAlkemyPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosModelsController : ControllerBase
    {
        private readonly AlkemyDbContext _context;

        public UsuariosModelsController(AlkemyDbContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuariosModel>>> GetUsuariosModels()
        {
          if (_context.UsuariosModels == null)
          {
              return NotFound();
          }
            return await _context.UsuariosModels.ToListAsync();
        }

        // GET: api/UsuariosModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuariosModel>> GetUsuariosModel(int id)
        {
          if (_context.UsuariosModels == null)
          {
              return NotFound();
          }
            var usuariosModel = await _context.UsuariosModels.FindAsync(id);

            if (usuariosModel == null)
            {
                return NotFound();
            }

            return usuariosModel;
        }

        // PUT: api/UsuariosModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuariosModel(int id, UsuariosModel usuariosModel)
        {
            if (id != usuariosModel.CodUsuario)
            {
                return BadRequest();
            }

            _context.Entry(usuariosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosModelExists(id))
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

        // POST: api/UsuariosModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuariosModel>> PostUsuariosModel(UsuariosModel usuariosModel)
        {
          if (_context.UsuariosModels == null)
          {
              return Problem("Entity set 'AlkemyDbContext.UsuariosModels'  is null.");
          }
            _context.UsuariosModels.Add(usuariosModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuariosModel", new { id = usuariosModel.CodUsuario }, usuariosModel);
        }

        // DELETE: api/UsuariosModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuariosModel(int id)
        {
            if (_context.UsuariosModels == null)
            {
                return NotFound();
            }
            var usuariosModel = await _context.UsuariosModels.FindAsync(id);
            if (usuariosModel == null)
            {
                return NotFound();
            }

            _context.UsuariosModels.Remove(usuariosModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuariosModelExists(int id)
        {
            return (_context.UsuariosModels?.Any(e => e.CodUsuario == id)).GetValueOrDefault();
        }
    }
}
