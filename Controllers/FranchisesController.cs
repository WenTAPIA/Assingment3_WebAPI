#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharacterAPI.Models;
using MovieCharacterAPI.Models.DTO.Character;
using MovieCharacterAPI.Models.DTO.Franchise;
using MovieCharacterAPI.Models.DTO.Movie;
using MovieCharacterAPI.Services;

namespace MovieCharacterAPI.Controllers
{
  
    [Route("api/v1/franchises")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchisesController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFranchiseServices _franchiseServices;
        public FranchisesController(MovieDbContext context, IMapper mapper, IFranchiseServices franchiseServices)
        {
            _context = context;
            _mapper = mapper;
            _franchiseServices = franchiseServices;
        }
        #region Generic CRUD with DTOs
        /// <summary>
        /// Get all the Franchises in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetFranchise()
        {
            return _mapper.Map<List<FranchiseReadDTO>>(await _context.Franchise
               .Include(c => c.Movies)
               .ToListAsync());

        }
      
        /// <summary>
        /// Get Franchises by Id in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
            if (!_franchiseServices.FranchiseExists(id))
            {
                return NotFound("The franchise is not Found");
            }
            var domainFranchise = await _context.Franchise.Include(c => c.Movies).FirstOrDefaultAsync(f => f.Id == id);

          

            return _mapper.Map<FranchiseReadDTO>(domainFranchise);
        }

        /// <summary>
        /// Updates a Franchise. Must pass a full Franchise object and Id in route.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateFranchise"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutFranchise(int id, FranchiseEditDTO updateFranchise)
        {

            if (!_franchiseServices.FranchiseExists(id))
            {
                return NotFound("The franchise is not Found");
            }
            if (id != updateFranchise.Id)
            {
                return BadRequest("Invalid Id");
            }
            Franchise domainFranchise = _mapper.Map<Franchise>(updateFranchise);
            _context.Entry(domainFranchise).State = EntityState.Modified;

            var updated = await _context.SaveChangesAsync();
            if (updated == id)
                return Ok();
            else return NotFound();
            //update check exist first if not NOTFOUND
        }

        /// <summary>
        /// Adds a new Franchise to the database.
        /// </summary>
        /// <param name="dtoFranchise"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Franchise>> PostFranchise([FromBody] FranchiseCreateDTO dtoFranchise)
        {
            Franchise domainFranchise =_mapper.Map<Franchise>(dtoFranchise);
            _context.Franchise.Add(domainFranchise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFranchise", new { id = domainFranchise.Id },
                                    _mapper.Map<FranchiseReadDTO>(domainFranchise));
        }

        /// <summary>
        /// Deletes a Franchise from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            if (!_franchiseServices.FranchiseExists(id))
            {
                return NotFound("The franchise is not Found");
            }
            var franchise = await _context.Franchise.FindAsync(id);
            

            _context.Franchise.Remove(franchise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

       
        #endregion

        #region Reporting
        /// <summary>
        /// return movies connected to specific franchise
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("movie")]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovieInFranchise()
        { //to implement
            var character = await _context.Character.FindAsync(1);
            return null;

        }

        /// <summary>
        /// return character connected to specific franchise
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("characters")]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacterInFranchise()
        { //to implement
            var character = await _context.Character.FindAsync(1);
            return null;

        }
        #endregion

        #region Updating
        /// <summary>
        ///Complete Update which movies connected to franchise
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/movies")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]


        public async Task<IActionResult> UpdateCharactersInMovie(int id, [FromBody] List<int> movieIdList)
        { 


                if (!_franchiseServices.FranchiseExists(id))
            {
                    return NotFound("The franchise is not Found");
                }
                try
                {
                    await _franchiseServices.UpdateMoviesInFranchiseAsync(id, movieIdList);
                }
                catch (KeyNotFoundException)
                {
                    return BadRequest("Invalid Franchise");
                }
                return Ok();

          

            //var character = await _context.Character.FindAsync(1);
            //return null;

        }


        #endregion
       
    }
}
