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
    //[Authorize]
    public class TrabajosModelsController : ControllerBase
    {
        private readonly AlkemyDbContext _context;

        public TrabajosModelsController(AlkemyDbContext context)
        {
            _context = context;
        }

        // GET: api/TrabajosModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrabajosModel>>> GetTrabajosModels()
        {
          if (_context.TrabajosModels == null)
          {
              return NotFound();
          }
            return await _context.TrabajosModels.ToListAsync();
        }

        // GET: api/TrabajosModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrabajosModel>> GetTrabajosModel(int id)
        {
          if (_context.TrabajosModels == null)
          {
              return NotFound();
          }
            var trabajosModel = await _context.TrabajosModels.FindAsync(id);

            if (trabajosModel == null)
            {
                return NotFound();
            }

            return trabajosModel;
        }

        // PUT: api/TrabajosModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrabajosModel(int id, TrabajosModel trabajosModel)
        {
            if (id != trabajosModel.CodTrabajo)
            {
                return BadRequest();
            }

            _context.Entry(trabajosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrabajosModelExists(id))
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

        // POST: api/TrabajosModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrabajosModel>> PostTrabajosModel(TrabajosModel trabajosModel)
        {
          if (_context.TrabajosModels == null)
          {
              return Problem("Entity set 'AlkemyDbContext.TrabajosModels'  is null.");
          }
            _context.TrabajosModels.Add(trabajosModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrabajosModel", new { id = trabajosModel.CodTrabajo }, trabajosModel);
        }

        // DELETE: api/TrabajosModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabajosModel(int id)
        {
            if (_context.TrabajosModels == null)
            {
                return NotFound();
            }
            var trabajosModel = await _context.TrabajosModels.FindAsync(id);
            if (trabajosModel == null)
            {
                return NotFound();
            }

            _context.TrabajosModels.Remove(trabajosModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrabajosModelExists(int id)
        {
            return (_context.TrabajosModels?.Any(e => e.CodTrabajo == id)).GetValueOrDefault();
        }
    }
}
