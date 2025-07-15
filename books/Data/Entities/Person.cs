using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyBlazorApp.Data.Entities
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        [Required]
        public string LastName { get; set; } = null!;
        public string? Note { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        [Required]  
        public City City { get; set; } = null!;
        public List<Phone> Phones { get; set; } = new();
    }
}