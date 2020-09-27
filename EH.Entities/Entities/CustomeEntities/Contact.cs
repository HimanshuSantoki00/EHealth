using System.ComponentModel.DataAnnotations;

namespace EH.Entities.Entities.CustomeEntities
{
    public class Contact
    {
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Please enter valid email.")]
        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(320)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(10)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter valid phone number.")]
        public string Phone { get; set; }
        public bool Status { get; set; }

    }
}
