namespace ProjectTirUsersMicroservice.API.Contracts.UsersEndpoints.Response
{
    [Serializable]
    public class UserResponse
    {
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string? Patronymic { get; set; }

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateOnly BirthdayDate { get; set; }
    }
}
