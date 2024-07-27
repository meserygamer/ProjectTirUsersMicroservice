using Microsoft.AspNetCore.Mvc;
using ProjectTirUsersMicroservice.API.Contracts.UsersEndpoints.Requests;
using ProjectTirUsersMicroservice.API.Contracts.UsersEndpoints.Response;
using System.ComponentModel.DataAnnotations;
using Mapster;
using ProjectTirUsersMicroservice.Core.DomainEntities;
using ProjectTirUsersMicroservice.Core.RepositoryInterfaces;

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

        private static async Task<IResult> GetUserById([FromQuery] int userId,
            IUserRepository userRepository)
        {
            if (userId < 1)
                return Results.BadRequest("UserId must bigger than or equal to 1");

            User response = await userRepository.GetUserByIdAsync(userId);
            return Results.Json(response.Adapt<UserResponse>());
        }

        private static async Task<IResult> CreateUser([FromBody] CreateUserRequest request,
            IUserRepository userRepository)
        {
            if (!ValidateCreateUserRequest(request, out List<ValidationResult> errors))
                return Results.BadRequest(errors);
            
            User response = await userRepository.AddUserAsync(request.Adapt<User>());
            return Results.Json(response.Adapt<UserResponse>());
        }

        private static bool ValidateCreateUserRequest(CreateUserRequest request, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(request);
            return Validator.TryValidateObject(request, context, errors, true);
        }
    }
}
