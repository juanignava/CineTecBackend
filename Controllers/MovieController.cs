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
    public class MovieController : ControllerBase
    {
        private readonly cinetecContext _context;
        public MovieController(cinetecContext context)
        {
            _context = context;
        }

        // Get all movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();

        }

        // Get a movie by name
        [HttpGet("{name}")]
        public async Task<ActionResult<Movie>> GetMovie(string name)
        {
            return await _context.Movies.FindAsync(name);

        }

        // Post a movie
        [HttpPost]
        public async Task<ActionResult> Add(Movie movie)
        {
            var itemToAdd = await _context.Movies.FindAsync(movie.OriginalName);
            if (itemToAdd != null)
                return Conflict();
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Update a movie
        [HttpPut("{name}")]
        public async Task<ActionResult> UpdateMovie(string name, Movie movie)
        {
            var itemToUpdate = await _context.Movies.FindAsync(name);
            if (itemToUpdate == null)
                return NotFound();
            itemToUpdate.Gendre = movie.Gendre;
            itemToUpdate.Name = movie.Name;
            itemToUpdate.Director = movie.Director;
            itemToUpdate.Lenght = movie.Lenght;

            await _context.SaveChangesAsync();
            return Ok();
        }

        // Delete a movie
        [HttpDelete("{name}")]
        public async Task<ActionResult> DeleteMovie(string name)
        {
            var itemToRemove = await _context.Movies.FindAsync(name);

            if (itemToRemove == null)
                return NotFound();

            _context.Movies.Remove(itemToRemove);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}