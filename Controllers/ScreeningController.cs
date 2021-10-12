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

        
        // Get screening per theater per movie
        [HttpGet("filter_screening/{theater_name}/{movie_name}")]
        public async Task<ActionResult<IEnumerable<Screening>>> GetScreeningPerTheater(string theater_name, string movie_name)
        {

            var screeningList = await _context.Screenings.FromSqlInterpolated($@"SELECT SC.ID, SC.Cinema_number, SC.Movie_original_name, SC.Hour, SC.Capacity 
                                                                            FROM SCREENING AS SC, CINEMA AS C, MOVIE_THEATER AS MT 
                                                                            WHERE SC.Cinema_number = C.Number AND C.Name_movie_theater = MT.Name 
                                                                            AND MT.Name = {theater_name} AND SC.Movie_original_name = {movie_name}").ToListAsync();
            
            return screeningList;
        }
        

        // Post a screening
        [HttpPost]
        public async Task<ActionResult> Add(Screening screening)
        {
            /*
            var itemToAdd = await _context.Screenings.FindAsync(screening.Id);
            if (itemToAdd != null)
                return Conflict();
            */

            var screening_cinema = await _context.Cinemas.FindAsync(screening.CinemaNumber);
            var screening_movie = await _context.Movies.FindAsync(screening.MovieOriginalName);

            if(screening_cinema == null || screening_movie == null) return Conflict();

            var screenings = await _context.Screenings.ToListAsync();

            int max = 0;

            foreach (var screen in screenings)
            {
                if (screen.Id > max)
                {
                    max = screen.Id;
                }
            }

            Console.WriteLine(max);
            screening.Id = max+1;

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
            //var param = new SqlParameter("@param", id.ToString());
            var seats = _context.Seats.Where(seat => seat.ScreeningId == id);
            
            foreach (var seat in seats)
            {
                _context.Seats.Remove(seat);
            }
            await _context.SaveChangesAsync();

            var itemToRemove = await _context.Screenings.FindAsync(id);

            if (itemToRemove == null)
                return NotFound();

            _context.Screenings.Remove(itemToRemove);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}