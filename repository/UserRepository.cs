using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
namespace repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Store21Context _DbContext;

        public UserRepository( Store21Context  dbContext )
        {
            _DbContext = dbContext;
        }
        public  async Task<User> getUserByUserNameAndPassword(string userName, string password)
        {
            return await _DbContext.Users.Where(user => user.Email == userName && user.Password == password).FirstOrDefaultAsync();
        }
        public  async Task<User> CreateNewUser(User user)
        {
           await  _DbContext.AddAsync(user);
           await _DbContext.SaveChangesAsync();
            return user;
         
        }
        public async Task Put(int id, User userToUpdate)
        {
            userToUpdate.UserId = id;
            _DbContext.
                
                
                
                
                Users.Update(userToUpdate);
           await _DbContext.SaveChangesAsync();
        }
    }
}