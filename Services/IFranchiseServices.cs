using Microsoft.EntityFrameworkCore;
using MovieCharacterAPI.Models;

namespace MovieCharacterAPI.Services
{
    /// <summary>
    /// This is a interface for Franchise Repository.
    /// </summary>
    public interface IFranchiseServices
    {
        
        
        public Task UpdateMoviesInFranchiseAsync(int id, List<int> charactersIdList);
        public Task <IEnumerable<Movie>> GetMovieInFranchise(int id);
        public bool FranchiseExists(int id);
    }
    
}
