using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAlkemyPI;
using ApiAlkemyPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiAlkemyPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProyectosModelsController : ControllerBase
    {
        private readonly AlkemyDbContext _context;

        public ProyectosModelsController(AlkemyDbContext context)
        {
            _context = context;
        }

        // GET: api/ProyectosModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProyectosModel>>> GetProyectosModels()
        {
          if (_context.ProyectosModels == null)
          {
              return NotFound();
          }
            return await _context.ProyectosModels.ToListAsync();
        }

        // GET: api/ProyectosModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProyectosModel>> GetProyectosModel(int id)
        {
          if (_context.ProyectosModels == null)
          {
              return NotFound();
          }
            var proyectosModel = await _context.ProyectosModels.FindAsync(id);

            if (proyectosModel == null)
            {
                return NotFound();
            }

            return proyectosModel;
        }

        // PUT: api/ProyectosModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyectosModel(int id, ProyectosModel proyectosModel)
        {
            if (id != proyectosModel.CodProyecto)
            {
                return BadRequest();
            }

            _context.Entry(proyectosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectosModelExists(id))
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

        // POST: api/ProyectosModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProyectosModel>> PostProyectosModel(ProyectosModel proyectosModel)
        {
          if (_context.ProyectosModels == null)
          {
              return Problem("Entity set 'AlkemyDbContext.ProyectosModels'  is null.");
          }
            _context.ProyectosModels.Add(proyectosModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProyectosModel", new { id = proyectosModel.CodProyecto }, proyectosModel);
        }

        // DELETE: api/ProyectosModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyectosModel(int id)
        {
            if (_context.ProyectosModels == null)
            {
                return NotFound();
            }
            var proyectosModel = await _context.ProyectosModels.FindAsync(id);
            if (proyectosModel == null)
            {
                return NotFound();
            }

            _context.ProyectosModels.Remove(proyectosModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProyectosModelExists(int id)
        {
            return (_context.ProyectosModels?.Any(e => e.CodProyecto == id)).GetValueOrDefault();
        }
    }
}
