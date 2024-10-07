using CoWorkSpace.Back.Data;
using CoWorkSpace.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoWorkSpace.Back.Controllers
{
    [ApiController]
    [Route("/Back/Eventos")]
    public class EventosController : ControllerBase
    {
        private readonly DataContext _context;
        public EventosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Eventos.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Evento evento)
        {
            _context.Add(evento);
            await _context.SaveChangesAsync();
            return Ok(evento);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var evento = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Evento evento)
        {
            _context.Update(evento);
            await _context.SaveChangesAsync();
            return Ok(evento);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var evento = await _context.Eventos.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (evento == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}