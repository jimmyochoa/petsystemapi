using backend.Models;
using System.ComponentModel.DataAnnotations;

namespace backend.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage ="First Name is required!")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last Name is required!")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Direction is required!")]
        public string Direction { get; set; } = null!;
        public int ProvinceId { get; set; }

    }
}
