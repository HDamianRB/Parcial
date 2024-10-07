using CoWorkSpace.Back.Data;
using CoWorkSpace.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoWorkSpace.Back.Controllers
{
    [ApiController]
    [Route("/Back/EspaciosTrabajo")]
    public class EspaciosTrabajoController : ControllerBase
    {
        private readonly DataContext _context;
        public EspaciosTrabajoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.EspaciosTrabajo.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(EspacioTrabajo espacio)
        {
            _context.Add(espacio);
            await _context.SaveChangesAsync();
            return Ok(espacio);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var espacio = await _context.EspaciosTrabajo.FirstOrDefaultAsync(x => x.Id == id);
            if (espacio == null)
            {
                return NotFound();
            }
            return Ok(espacio);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EspacioTrabajo espacio)
        {
            _context.Update(espacio);
            await _context.SaveChangesAsync();
            return Ok(espacio);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var espacio = await _context.EspaciosTrabajo.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (espacio == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}