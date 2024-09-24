using System.ComponentModel.DataAnnotations;

namespace HotelBooking.ViewModels
{
    public class RegisterVM
    {
        
        [Required]
        public string? LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match.")]
        public string? ConfirmPassword { get; set; }
        public string? Address { get; set; }
    }
}
