using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class UserDTO
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        [MinLength(8)]
        public string Password { get; set; } = null!;
        [MinLength(3)]
        public string? FirstName { get; set; }
        [MinLength(2),MaxLength(20)]
        public string? LastName { get; set; }

    }


}