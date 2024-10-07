using CoWorkSpace.Back.Data;
using CoWorkSpace.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoWorkSpace.Back.Controllers
{
    [ApiController]
    [Route("/Back/Membresias")]
    public class MembresiasController : ControllerBase
    {
        private readonly DataContext _context;
        public MembresiasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Membresias.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Membresia membresia)
        {
            _context.Add(membresia);
            await _context.SaveChangesAsync();
            return Ok(membresia);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var membresia = await _context.Membresias.FirstOrDefaultAsync(x => x.Id == id);
            if (membresia == null)
            {
                return NotFound();
            }
            return Ok(membresia);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Membresia membresia)
        {
            _context.Update(membresia);
            await _context.SaveChangesAsync();
            return Ok(membresia);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var membresia = await _context.Membresias.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (membresia == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
