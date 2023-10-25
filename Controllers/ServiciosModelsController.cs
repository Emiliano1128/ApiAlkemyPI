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
    public class ServiciosModelsController : ControllerBase
    {
        private readonly AlkemyDbContext _context;

        public ServiciosModelsController(AlkemyDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiciosModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiciosModel>>> GetServiciosModels()
        {
          if (_context.ServiciosModels == null)
          {
              return NotFound();
          }
            return await _context.ServiciosModels.ToListAsync();
        }

        // GET: api/ServiciosModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiciosModel>> GetServiciosModel(int id)
        {
          if (_context.ServiciosModels == null)
          {
              return NotFound();
          }
            var serviciosModel = await _context.ServiciosModels.FindAsync(id);

            if (serviciosModel == null)
            {
                return NotFound();
            }

            return serviciosModel;
        }

        // PUT: api/ServiciosModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiciosModel(int id, ServiciosModel serviciosModel)
        {
            if (id != serviciosModel.CodServicio)
            {
                return BadRequest();
            }

            _context.Entry(serviciosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosModelExists(id))
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

        // POST: api/ServiciosModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiciosModel>> PostServiciosModel(ServiciosModel serviciosModel)
        {
          if (_context.ServiciosModels == null)
          {
              return Problem("Entity set 'AlkemyDbContext.ServiciosModels'  is null.");
          }
            _context.ServiciosModels.Add(serviciosModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiciosModel", new { id = serviciosModel.CodServicio }, serviciosModel);
        }

        // DELETE: api/ServiciosModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiciosModel(int id)
        {
            if (_context.ServiciosModels == null)
            {
                return NotFound();
            }
            var serviciosModel = await _context.ServiciosModels.FindAsync(id);
            if (serviciosModel == null)
            {
                return NotFound();
            }

            _context.ServiciosModels.Remove(serviciosModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiciosModelExists(int id)
        {
            return (_context.ServiciosModels?.Any(e => e.CodServicio == id)).GetValueOrDefault();
        }
    }
}
