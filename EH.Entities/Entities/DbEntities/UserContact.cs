using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EH.Entities.Entities.DbEntities
{
    public class UserContact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(320)]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(10)")]
        public string Phone { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
