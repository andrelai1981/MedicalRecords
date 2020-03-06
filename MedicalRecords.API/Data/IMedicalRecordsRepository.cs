using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalRecords.API.Helpers;
using MedicalRecords.API.Models;

namespace MedicalRecords.API.Data
{
    public interface IMedicalRecordsRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<PagedList<Box>> GetBoxes(BoxParams boxParams);
        Task<Box> GetBox(int id);
        Task<bool> BoxExists(long barcodeNum);
        Task<int> GetNumberOfFilesInBox(int id);
        Task<Box> CreateBox(Box box);
        Task<User> CreateUser(User user, string password);
        Task<bool> UpdateUser(User user, string password);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<bool> IsAdmin(int id);
        Task<bool> UserExists(string userName);
        Task<PagedList<File>> GetFiles(FileParams fileParams);
        Task<File> GetFile(int id);
        Task<File> CreateFile(File file);
        // Task<IEnumerable<File>> GetFilesForBox(int id);
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int id);
        Task<IEnumerable<County>> GetCounties();
        Task<County> GetCounty(int id);
        Task<Client> GetClient(int id);
        Task<IEnumerable<Client>> GetClients();
    }
}