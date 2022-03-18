#nullable disable
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharacterAPI.Models;
using MovieCharacterAPI.Models.DTO.Character;
using MovieCharacterAPI.Models.DTO.Movie;
using MovieCharacterAPI.Services;
using System.Net;
using System.Net.Mime;

namespace MovieCharacterAPI.Controllers
{
    [Route("api/v1/movies")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMovieServices _movieServices;

        public MoviesController(MovieDbContext context, IMapper mapper, IMovieServices movieServices)
        {
            _context = context;
            _mapper = mapper;
            _movieServices = movieServices;
        }

        #region Generic CRUD with DTOs
        /// <summary>
        /// Get all the Movies in the database.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetAllMovies()
        {
            return _mapper.Map<List<MovieReadDTO>>(await _context.Movie
                 .Include(m => m.Characters)
                 .ToListAsync());
        }

        /// <summary>
        /// Get specific Movie by id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            var domainMovie = await _context.Movie.Include(m => m.Characters).FirstOrDefaultAsync(m => m.Id == id);

            if (!_movieServices.MovieExists(id))
            {
                return NotFound("The movie is not Found");
            }

            return _mapper.Map<MovieReadDTO>(domainMovie);
        }

        /// <summary>
        /// Updates a Movie. Must have a full movie object and Id in route.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateMovie"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutMovie(int id, MovieEditDTO updateMovie)
        {
            if (!_movieServices.MovieExists(id))
            {
                return NotFound("The movie is not Found");
            }

            if (id != updateMovie.Id)
            {
                return BadRequest();
            }

            Movie domainMovie = _mapper.Map<Movie>(updateMovie);
            _context.Entry(domainMovie).State = EntityState.Modified;

            await _context.SaveChangesAsync();


            return Ok();


        }

        /// <summary>
        /// Adds a new Movie to the database.
        /// </summary>
        /// <param name="dtoMovie"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<Movie>> PostMovie(MovieCreateDTO dtoMovie)
        {
            Movie domainMovie = _mapper.Map<Movie>(dtoMovie);
            _context.Movie.Add(domainMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = domainMovie.Id },
                 _mapper.Map<MovieReadDTO>(domainMovie));
        }

        /// <summary>
        /// Deletes a movie from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!_movieServices.MovieExists(id))
            {
                return NotFound("The movie is not Found");
            }

            var movie = await _context.Movie.FindAsync(id);

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        //not working ++++++review
        #region Reporting
        /// <summary>
        /// Return Characters Connected to Specific Movie
        /// </summary>
        ///  /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet("{id}/characters")]

        //[HttpGet]
        //[Route("movie")]
        //public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacterInFranchise(int id)
        //{ //to implement
        //    var characters = await _franchiseServices.GetCharactersInFranchise(id);
        //    return _mapper.Map<List<CharacterReadDTO>>(characters);

        //}
        //public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacterInMovie(int id)
        //{ //to implemet
        //    if (!_movieServices.MovieExists(id))
        //    {
        //        return NotFound("The movie is not Found");
        //    }
        //    try
        //    {
        //       var fechtedCharacters = await _movieServices.GetCharactersinMovieAsync(id);
        //        return _mapper.Map<CharacterReadDTO>(fechtedCharacters);

        //    }
        //    catch (KeyNotFoundException)
        //    {
        //        return BadRequest("Invalid Characters");
        //    }
        //    return NoContent();


        //}

        #endregion

        #region Updating
        /// <summary>
        /// Update Characters Connected to Specific Movie
        /// </summary>
        /// <param name = "id" ></ param >
        /// /// <param name="charactersIdList"></param>
        /// < returns ></ returns >
        [HttpPut("{id}/characters")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCharactersInMovie(int id, [FromBody] List<int> charactersIdList)
        {


            if (!_movieServices.MovieExists(id))
            {
                return NotFound("The movie is not Found");
            }
            try
            {
                await _movieServices.UpdateCharacterinMovieAsync(id, charactersIdList);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Invalid Characters");
            }
            return NoContent();

        }

        #endregion

    }
}
