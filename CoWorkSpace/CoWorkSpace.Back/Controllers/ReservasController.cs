using CoWorkSpace.Back.Data;
using CoWorkSpace.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoWorkSpace.Back.Controllers
{
    [ApiController]
    [Route("/Back/Reservas")]
    public class ReservasController : ControllerBase
    {
        private readonly DataContext _context;
        public ReservasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Reservas.Include(r => r.Miembro).Include(r => r.EspacioTrabajo).ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Reserva reserva)
        {
            _context.Add(reserva);
            await _context.SaveChangesAsync();
            return Ok(reserva);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var reserva = await _context.Reservas.Include(r => r.Miembro).Include(r => r.EspacioTrabajo).FirstOrDefaultAsync(x => x.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }
            return Ok(reserva);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Reserva reserva)
        {
            _context.Update(reserva);
            await _context.SaveChangesAsync();
            return Ok(reserva);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var reserva = await _context.Reservas.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (reserva == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}