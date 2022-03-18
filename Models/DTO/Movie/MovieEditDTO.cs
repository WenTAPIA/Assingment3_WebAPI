namespace MovieCharacterAPI.Models.DTO.Movie
{
    public class MovieEditDTO
    {

        /// <summary>
        /// DTO to  Update a Movie
        /// </summary>
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }


    }
}
