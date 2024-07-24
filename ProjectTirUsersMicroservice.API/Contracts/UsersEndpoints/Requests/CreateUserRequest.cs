using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectTirUsersMicroservice.API.Contracts.UsersEndpoints.Requests
{
    [Serializable]
    public class CreateUserRequest
    {
        [Required]
        [Length(1, 100, ErrorMessage = "User name must have a length between 1 and 100")]
        public string Name { get; set; } = null!;

        [Required]
        [Length(1, 100, ErrorMessage = "User surname must have a length between 1 and 100")]
        public string Surname { get; set; } = null!;

        public string? Patronymic { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Incorrect email format")]
        public string Email { get; set; } = null!;

        [Required]
        [Phone(ErrorMessage = "Incorrect phone number")]
        public string Phone { get; set; } = null!;

        [Required]
        public DateOnly BirthdayDate { get; set; }
    }
}
