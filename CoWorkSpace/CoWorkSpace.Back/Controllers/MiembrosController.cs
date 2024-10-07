using CoWorkSpace.Back.Data;
using CoWorkSpace.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoWorkSpace.Back.Controllers
{
    [ApiController]
    [Route("/Back/Miembros")]
    public class MiembrosController : ControllerBase
    {
        private readonly DataContext _context;
        public MiembrosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Miembros.Include(m => m.Membresia).ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Miembro miembro)
        {
            _context.Add(miembro);
            await _context.SaveChangesAsync();
            return Ok(miembro);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var miembro = await _context.Miembros.Include(m => m.Membresia).FirstOrDefaultAsync(x => x.Id == id);
            if (miembro == null)
            {
                return NotFound();
            }
            return Ok(miembro);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Miembro miembro)
        {
            _context.Update(miembro);
            await _context.SaveChangesAsync();
            return Ok(miembro);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var miembro = await _context.Miembros.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (miembro == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}