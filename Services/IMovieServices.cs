using MovieCharacterAPI.Models;

namespace MovieCharacterAPI.Services
{
    /// <summary>
    /// This is a interface for Movie Repository.
    /// </summary>
    public interface IMovieServices
    {


        public Task UpdateCharacterinMovieAsync(int id, List<int> charactersIdList);
       
        public bool MovieExists(int id);
    }

}
