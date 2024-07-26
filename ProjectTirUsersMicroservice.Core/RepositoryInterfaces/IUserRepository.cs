using ProjectTirUsersMicroservice.Core.DomainEntities;

namespace ProjectTirUsersMicroservice.Core.RepositoryInterfaces
{
    public interface IUserRepository
    {
        public Task<bool> AddUserAsync(User user);

        public Task<User> GetUserByIdAsync(int userId);
    }
}
