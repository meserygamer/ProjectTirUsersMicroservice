using ProjectTirUsersMicroservice.Core.DomainEntities;

namespace ProjectTirUsersMicroservice.Core.RepositoryInterfaces
{
    public interface IUserRepository
    {
        public Task<User> AddUserAsync(User user);

        public Task<User> GetUserByIdAsync(int userId);
    }
}
