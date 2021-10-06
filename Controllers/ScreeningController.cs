using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CineTecBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScreeningController : ControllerBase
    {
        private readonly cinetecContext _context;
        public ScreeningController(cinetecContext context)
        {
            _context = context;
        }

        // Get all screenings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Screening>>> GetScreenings()
        {
            return await _context.Screenings.ToListAsync();

        }

        // Get a screening by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Screening>> GetScreening(int id)
        {
            return await _context.Screenings.FindAsync(id);

        }

        // Post a screening
        [HttpPost]
        public async Task<ActionResult> Add(Screening screening)
        {
            var itemToAdd = await _context.Screenings.FindAsync(screening.Id);
            if (itemToAdd != null)
                return Conflict();
            _context.Screenings.Add(screening);
            await _context.SaveChangesAsync();

            var itemAddedCinema = await _context.Cinemas.FindAsync(screening.CinemaNumber);

            for (int i = 1; i <= itemAddedCinema.Rows; i++)
            {
                for (int j = 1; j <= itemAddedCinema.Columns; j++)   {
                    
                    Seat seat = new ()
                    {
                        ScreeningId = screening.Id,
                        RowNum = i,
                        ColumnNum = j,
                        State = "free"
                    };

                    _context.Seats.Add(seat);
                    await _context.SaveChangesAsync();
                }
            }

            return Ok();
        }

        // Update a screening
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateScreening(int id, Screening screening)
        {
            var itemToUpdate = await _context.Screenings.FindAsync(id);
            if (itemToUpdate == null)
                return NotFound();
            itemToUpdate.Hour = screening.Hour;
            itemToUpdate.Capacity = screening.Capacity;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Delete a screening
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteScreening(int id)
        {
            var itemToRemove = await _context.Screenings.FindAsync(id);

            if (itemToRemove == null)
                return NotFound();

            _context.Screenings.Remove(itemToRemove);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}