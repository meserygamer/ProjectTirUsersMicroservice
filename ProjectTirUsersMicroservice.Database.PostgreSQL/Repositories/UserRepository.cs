using ProjectTirUsersMicroservice.Core.DomainEntities;
using ProjectTirUsersMicroservice.Core.RepositoryInterfaces;

namespace ProjectTirUsersMicroservice.Database.PostgreSQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(MicroserviceDbContext context)
        {
            _context = context;
        }


        private readonly MicroserviceDbContext _context;
        
        
        public User AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
