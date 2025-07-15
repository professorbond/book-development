using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyBlazorApp.Data.Entities
{
    [Table("Phones")]
    public class Phone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]  
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public bool IsBankLinked { get; set; }
        [Required]
        public string PhoneType { get; set; } = null!;
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public Person Person { get; set; } = null!;
    }

}