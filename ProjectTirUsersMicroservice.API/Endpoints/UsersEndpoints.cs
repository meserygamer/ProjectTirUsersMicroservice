using ProjectTirUsersMicroservice.API.Contracts.UsersEndpoints.Response;

namespace ProjectTirUsersMicroservice.API.Endpoints
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder AddUsersEndpoints(this IEndpointRouteBuilder builder) 
        {
            var group = builder.MapGroup("Users");

            group.MapGet("GetUserById", GetUserById);

            return builder;
        }

        private static async Task<UserResponse> GetUserById()
        {
            return new UserResponse();
        }
    }
}
