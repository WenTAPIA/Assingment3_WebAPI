namespace MovieCharacterAPI.Models.DTO.Franchise
{

    /// <summary>
    /// DTO to  Update a Franchise
    /// </summary>
    public class FranchiseEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
