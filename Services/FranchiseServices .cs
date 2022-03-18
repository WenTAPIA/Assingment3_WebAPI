using Microsoft.EntityFrameworkCore;
using MovieCharacterAPI.Models;

namespace MovieCharacterAPI.Services
{
    /// <summary>
    /// This is a repository for Franchise
    /// </summary>
    public class FranchiseServices : IFranchiseServices
    {
        private readonly MovieDbContext _context;
        public FranchiseServices(MovieDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// This methode is to update characters in a movie.
        /// </summary>
        public async Task UpdateMoviesInFranchiseAsync(int franchiseId, List<int> movieList)
        {
            Franchise franchiseToUpdateMovie = await _context.Franchise
                .Include(f => f.Movies)
                .Where(f => f.Id == franchiseId)
                .FirstAsync();

            // Loop through characters, try and assign to movie
            List<Movie> fetchMovies = new();
            foreach (int movieId in movieList)
            {
                Movie updMovie = await _context.Movie.FindAsync(movieId);

                fetchMovies.Add(updMovie);

            }
            franchiseToUpdateMovie.Movies = fetchMovies;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetMovieInFranchise(int franchiseId)
        {

            var charactersMovie = _context.Franchise.Include(x => x.Movies).Single(x => x.Id == franchiseId);
            List<Movie> characterList = new();
            //foreach(var character in character)
            //{
            //    characterList.Add(character);
            //}


            return characterList;

        }
        /// <summary>
        /// this methode is to validate if a movie exist in the Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FranchiseExists(int id)
        {
            return _context.Franchise.Any(f => f.Id == id);
        }
    }
}
