using Microsoft.AspNetCore.Mvc;
using ProjectTirUsersMicroservice.API.Contracts.UsersEndpoints.Requests;
using ProjectTirUsersMicroservice.API.Contracts.UsersEndpoints.Response;
using System.ComponentModel.DataAnnotations;

namespace ProjectTirUsersMicroservice.API.Endpoints
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder AddUsersEndpoints(this IEndpointRouteBuilder builder) 
        {
            var group = builder.MapGroup("Users");

            group.MapGet("GetUserById", GetUserById);
            group.MapPost("CreateUser", CreateUser);

            return builder;
        }

        private static async Task<UserResponse> GetUserById([FromQuery] int userId)
        {
            return new UserResponse();
        }

        private static async Task<IResult> CreateUser([FromBody] CreateUserRequest request)
        {
            if (!ValidateCreateUserRequest(request, out List<ValidationResult> errors))
                return Results.BadRequest(errors);

            return Results.Json(request);
        }

        private static bool ValidateCreateUserRequest(CreateUserRequest request, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(request);
            return Validator.TryValidateObject(request, context, errors, true);
        }
    }
}
