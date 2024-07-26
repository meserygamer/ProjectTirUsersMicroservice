using Mapster;
using Microsoft.EntityFrameworkCore;
using ProjectTirUsersMicroservice.Core.DomainEntities;
using ProjectTirUsersMicroservice.Core.RepositoryInterfaces;
using ProjectTirUsersMicroservice.Database.PostgreSQL.Entities;

namespace ProjectTirUsersMicroservice.Database.PostgreSQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(MicroserviceDbContext context)
        {
            _context = context;
        }


        private readonly MicroserviceDbContext _context;
        
        
        public async Task<bool> AddUserAsync(User user)
        {
            UserEntity dbEntity = user.Adapt<UserEntity>();
            try
            {
                await _context.Users.AddAsync(dbEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            try
            {
                UserEntity dbEntity = await _context.Users.FirstAsync(e => e.Id == userId);
                return dbEntity.Adapt<User>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
