using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCharacterAPI.Models
{
    [Table("Character")]
    /// <summary>
    /// Set the attributes for  Entity 
    /// </summary>
    public class Character
    {
        //PK
        public int Id { get; set; }
        //Fields
        [MaxLength(50)]
        public string FullName { get; set; }
        [MaxLength(30)] public string Alias { get; set; }
        [MaxLength(15)] public string Gender { get; set; }
        public string Picture { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}
