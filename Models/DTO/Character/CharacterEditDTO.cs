namespace MovieCharacterAPI.Models.DTO.Character
{
    public class CharacterEditDTO
    {
        /// <summary>
        /// DTO to  Update a Character
        /// </summary>
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }

        //public List<int>? Movies { get; set; }

    }
}
