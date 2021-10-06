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
    public class CinemaController : ControllerBase
    {
        private readonly cinetecContext _context;
        public CinemaController(cinetecContext context)
        {
            _context = context;
        }

        // Get all cinemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cinema>>> GetCinemas()
        {
            return await _context.Cinemas.ToListAsync();

        }

        // Get a cinema by id
        [HttpGet("{number}")]
        public async Task<ActionResult<Cinema>> GetCinema(int number)
        {
            return await _context.Cinemas.FindAsync(number);

        }

        // Post a cinema
        [HttpPost]
        public async Task<ActionResult> Add(Cinema cinema)
        {
            var itemToAdd = await _context.Cinemas.FindAsync(cinema.Number);

            var itemToAddMovieTheater = await _context.MovieTheaters.FindAsync(cinema.NameMovieTheater);
            if (itemToAdd != null || itemToAddMovieTheater == null)
                return Conflict();

            _context.Cinemas.Add(cinema);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Update a cinema
        [HttpPut("{number}")]
        public async Task<ActionResult> UpdateCinema(int number, Cinema cinema)
        {
            var itemToUpdate = await _context.Cinemas.FindAsync(number);
            if (itemToUpdate == null)
                return NotFound();

            var itemToUpdateMovieTheater = await _context.MovieTheaters.FindAsync(cinema.NameMovieTheater);
            if (itemToUpdateMovieTheater == null)
                return Conflict();
            
            itemToUpdate.Rows = cinema.Rows;
            itemToUpdate.Columns = cinema.Columns;

            await _context.SaveChangesAsync();
            return Ok();
        }

        // Delete a cinema
        [HttpDelete("{number}")]
        public async Task<ActionResult> DeleteCinema(int number)
        {
            var itemToRemove = await _context.Cinemas.FindAsync(number);

            if (itemToRemove == null)
                return NotFound();

            _context.Cinemas.Remove(itemToRemove);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}