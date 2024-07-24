using ProjectTirUsersMicroservice.Core.DomainEntities;

namespace ProjectTirUsersMicroservice.Core.RepositoryInterfaces
{
    public interface IUserRepository
    {
        public User AddUser(User user);

        public User GetUserById(int userId);
    }
}
