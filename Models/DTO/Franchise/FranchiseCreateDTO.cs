using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.Models.DTO.Franchise
{
    /// <summary>
    /// DTO to  create a Franchise
    /// </summary>
    public class FranchiseCreateDTO
    {
        [Required(ErrorMessage = "Full Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
