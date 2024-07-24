using Microsoft.AspNetCore.Mvc;
using ProjectTirUsersMicroservice.API.Contracts.UsersEndpoints.Requests;
using ProjectTirUsersMicroservice.API.Contracts.UsersEndpoints.Response;

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

        private static async Task<UserResponse> CreateUser([FromBody] CreateUserRequest request)
        {
            return new UserResponse();
        }
    }
}
