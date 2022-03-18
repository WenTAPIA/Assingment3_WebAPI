namespace MovieCharacterAPI.Models.DTO.Franchise
{
    public class FranchiseReadDTO
    {/// <summary>
     /// DTO to  Get the values of Franchise(s)
     /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> Movies { get; set; }
    }
}
