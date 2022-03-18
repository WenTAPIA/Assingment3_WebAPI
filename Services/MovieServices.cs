using Microsoft.EntityFrameworkCore;
using MovieCharacterAPI.Models;

namespace MovieCharacterAPI.Services
{
    /// <summary>
    /// This is a repository for Movie
    /// </summary>
    public class MovieServices : IMovieServices
    {
        private readonly MovieDbContext _context;
        public MovieServices(MovieDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// This methode is to update characters in a movie.
        /// </summary>
        public async Task UpdateCharacterinMovieAsync(int movieId, List<int> charactersList)
        {
            Movie movieToUpdateCharacter = await _context.Movie
                .Include(m => m.Characters)
                .Where(m => m.Id == movieId)
                .FirstAsync();

            // Loop through characters, try and assign to movie
            List<Character> fetchCharacters = new();
            foreach (int characterId in charactersList)
            {
                Character updCharacter = await _context.Character.FindAsync(characterId);

                fetchCharacters.Add(updCharacter);

            }
            movieToUpdateCharacter.Characters = fetchCharacters;
            await _context.SaveChangesAsync();
        }


        public bool MovieExists(int id)
        {
            return _context.Movie.Any(m => m.Id == id);
        }
    }
}
