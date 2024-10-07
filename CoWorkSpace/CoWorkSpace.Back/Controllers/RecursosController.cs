using CoWorkSpace.Back.Data;
using CoWorkSpace.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoWorkSpace.Back.Controllers
{
    [ApiController]
    [Route("/Back/Recursos")]
    public class RecursosController : ControllerBase
    {
        private readonly DataContext _context;
        public RecursosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Recursos.Include(r => r.EspacioTrabajo).ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Recurso recurso)
        {
            _context.Add(recurso);
            await _context.SaveChangesAsync();
            return Ok(recurso);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var recurso = await _context.Recursos.Include(r => r.EspacioTrabajo).FirstOrDefaultAsync(x => x.Id == id);
            if (recurso == null)
            {
                return NotFound();
            }
            return Ok(recurso);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Recurso recurso)
        {
            _context.Update(recurso);
            await _context.SaveChangesAsync();
            return Ok(recurso);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var recurso = await _context.Recursos.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (recurso == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
