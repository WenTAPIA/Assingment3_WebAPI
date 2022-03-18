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
using MovieCharacterAPI.Models.DTO.Movie;

namespace MovieCharacterAPI.Controllers
{
    [Route("api/v1/characters")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]

    public class CharactersController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;
        public CharactersController(MovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        # region Generic CRUD with DTOs
        /// <summary>
        /// Get all the Characters in the database.
        /// </summary>
        /// <returns></returns>
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacter()
        {
            return _mapper.Map<List<CharacterReadDTO>>(await _context.Character
                .Include(c => c.Movies)
                .ToListAsync());

        }
        /// <summary>
        /// Get specific Character by Id.
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
            if (!CharacterExists(id))
            {
                return NotFound("The character is not Found");
            }
            var domaincharacter = await _context.Character.Include(c =>c.Movies).FirstOrDefaultAsync(c => c.Id == id);

            if (domaincharacter == null)
            {
                return NotFound();
            }
       
            return _mapper.Map<CharacterReadDTO>(domaincharacter);
        }

        /// <summary>
        /// Updates a character. Must have a full character object and Id in route.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCharacter"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutCharacter(int id, CharacterEditDTO updateCharacter)
        {
            if (!CharacterExists(id))
            {
                return NotFound("The character is not Found");
            }
            if (id != updateCharacter.Id)
            {
                return BadRequest();
            }
          
            Character domainCharacter = _mapper.Map<Character>(updateCharacter);
            _context.Entry(domainCharacter).State = EntityState.Modified;

            await _context.SaveChangesAsync();


            return Ok();
          
        }

        /// <summary>
        /// Adds a new character to the database.
        /// </summary>
        /// <param name="dtoCharacter"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Character>> PostCharacter([FromBody]CharacterCreateDTO dtoCharacter)
        {
            Character domainCharacter = _mapper.Map<Character>(dtoCharacter);
            _context.Character.Add(domainCharacter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacter", 
                   new { id = domainCharacter.Id },
                   _mapper.Map<CharacterReadDTO>(domainCharacter));
        }
    /// <summary>
        /// Deletes a character from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (!CharacterExists(id))
            {
                return NotFound("The character is not Found");
            }
            var character = await _context.Character.FindAsync(id);
         
            _context.Character.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return _context.Character.Any(c => c.Id == id);
        }
        #endregion
       
        //

    }
}
