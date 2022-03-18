using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.Models.DTO.Movie
{
    /// <summary>
    /// DTO to  create a Movie
    /// </summary>
    public class MovieCreateDTO
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }
     
       
    }
}
