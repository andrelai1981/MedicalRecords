using System.Threading.Tasks;
using MedicalRecords.API.Models;

namespace MedicalRecords.API.Data
{
    public interface IAuthRepository
    {
        Task<User> CreateUser(User user, string password);
        Task<User> Login(string username, string password, bool isAdmin);
        Task<bool> UserExists(string username);
    }
}