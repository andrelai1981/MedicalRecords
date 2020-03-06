using System.Threading.Tasks;
using MedicalRecords.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalRecords.API.Data
{
  public class AuthRepository : IAuthRepository
  {
      private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context; 
        }
        public async Task<User> Login(string username, string password, bool isAdmin)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username); 

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
                 
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) 
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++) {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.UserName == username))
                return true;

            return false;
        }
  }
}