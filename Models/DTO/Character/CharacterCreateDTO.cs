using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.Models.DTO.Character
{ 
    /// <summary>
   /// DTO to  create a Character
   /// </summary>
    public class CharacterCreateDTO
    {
            [Required(ErrorMessage ="Full Name is required")]   
            public string FullName { get; set; }
            public string Alias { get; set; }      
            public string Gender { get; set; }
            public string Picture { get; set; }
                  
    }
}
