using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MovieCharacterAPI.Models
{
    [Table("Movie")]
    /// <summary>
    /// Set the attributes for  Entity 
    /// </summary>
    public class Movie
    {   
        //PK
        public int Id { get; set; }
        //Fields
        [MaxLength(50)] public string Title { get; set; }
        [MaxLength(100)] public string Genre { get; set; }
        [MaxLength(5)] public string ReleaseYear { get; set; }
        [MaxLength(30)] public string Director { get; set; }
        public string? Picture { get; set; }
        public string? Trailer { get; set; }
        //Relationships 
        //FK can be NULL
        public int? FranchiseId { get; set; }
        public Franchise? Franchise { get; set; }
        public ICollection<Character>? Characters { get; set;}
    }
}
