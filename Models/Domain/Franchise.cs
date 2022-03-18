using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCharacterAPI.Models
{
    [Table("Franchise")]
    /// <summary>
    /// Set the attributes for  Entity 
    /// </summary>
    public class Franchise
    {
        //PK
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(300)] public string Description { get; set; }
        //Navigation to Movies
        public ICollection<Movie>? Movies { get; set; }

    }
}
