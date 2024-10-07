using CoWorkSpace.Back.Data;
using CoWorkSpace.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoWorkSpace.Back.Controllers
{
    [ApiController]
    [Route("/Back/EventosMiembros")]
    public class EventosMiembrosController : ControllerBase
    {
        private readonly DataContext _context;
        public EventosMiembrosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.EventosMiembros.Include(em => em.Evento).Include(em => em.Miembro).ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(EventoMiembro eventoMiembro)
        {
            _context.Add(eventoMiembro);
            await _context.SaveChangesAsync();
            return Ok(eventoMiembro);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var eventoMiembro = await _context.EventosMiembros.Include(em => em.Evento).Include(em => em.Miembro).FirstOrDefaultAsync(x => x.Id == id);
            if (eventoMiembro == null)
            {
                return NotFound();
            }
            return Ok(eventoMiembro);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EventoMiembro eventoMiembro)
        {
            _context.Update(eventoMiembro);
            await _context.SaveChangesAsync();
            return Ok(eventoMiembro);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eventoMiembro = await _context.EventosMiembros.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (eventoMiembro == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}