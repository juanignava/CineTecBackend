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
    public class MovieTheaterController : ControllerBase
    {
        private readonly cinetecContext _context;
        public MovieTheaterController(cinetecContext context)
        {
            _context = context;
        }

        // Get all movie theaters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieTheater>>> GetMovieTheaters()
        {
            return await _context.MovieTheaters.ToListAsync();

        }

        // Get a movie theater by id
        [HttpGet("{name}")]
        public async Task<ActionResult<MovieTheater>> GetMovieTheater(string name)
        {
            return await _context.MovieTheaters.FindAsync(name);
        }

        // Post a movie theater
        [HttpPost]
        public async Task<ActionResult> Add(MovieTheater movieTheater)
        {
            var itemToAdd = await _context.MovieTheaters.FindAsync(movieTheater.Name);
            if (itemToAdd != null)
                return Conflict();
            _context.MovieTheaters.Add(movieTheater);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Update a movie theater
        [HttpPut("{name}")]
        public async Task<ActionResult> UpdateMovieTheater(string name, MovieTheater movieTheater)
        {
            var itemToUpdate = await _context.MovieTheaters.FindAsync(name);
            if (itemToUpdate == null)
                return NotFound();
            itemToUpdate.Location = movieTheater.Location;
            itemToUpdate.CinemaAmount = movieTheater.CinemaAmount;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Delete a movie theater
        [HttpDelete("{name}")]
        public async Task<ActionResult> DeleteMovieTheater(string name)
        {
            var itemToRemove = await _context.MovieTheaters.FindAsync(name);

            if (itemToRemove == null)
                return NotFound();

            _context.MovieTheaters.Remove(itemToRemove);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}