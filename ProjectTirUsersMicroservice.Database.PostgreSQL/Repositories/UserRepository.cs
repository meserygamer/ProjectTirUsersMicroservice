using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        
        
        public async Task<User> AddUserAsync(User user)
        {
            UserEntity dbEntity = user.Adapt<UserEntity>();
            try
            {
                EntityEntry<UserEntity> entityEntry = await _context.Users.AddAsync(dbEntity);
                await _context.SaveChangesAsync();
                await entityEntry.ReloadAsync();
                return entityEntry.Entity.Adapt<User>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
