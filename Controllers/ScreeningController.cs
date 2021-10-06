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

        /*
        // Get movies per theater
        [HttpGet("filter_theater/{name}")]
        public async Task<ActionResult<IEnumerable<Screening>>> GetMoviesPerTheater(string name)
        {
            var cinemaList = await _context.Cinemas.Where(p => p.NameMovieTheater == name).ToListAsync();

            List<int> numberProperty = cinemaList.Select(o => o.Number).ToList();

            var screeningList = await _context.Screenings.Where(p => numberProperty.Contains(p.CinemaNumber)).ToListAsync();
            return screeningList;
            /*
            return _context.Cinemas.Join(
                    _context.MovieTheaters,
                    cinema => cinema.NameMovieTheater,
                    movie_theater => movie_theater.Name,
                    (cinema, movie_theater) => new
                    {
                        cinema_num = cinema.Number,
                        movie_theater = movie_theater.Name
                    }
                    ).ToList();

            /*
            List<Screening> completeList = new List<Screening> ();
            foreach (Cinema cinema in cinemaList){
                var screen = await _context.Screenings.Where(p => p.CinemaNumber == cinema.Number).ToListAsync();;
                completeList.AddRange(screen);
            }
            return completeList;
            
        }
        */

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