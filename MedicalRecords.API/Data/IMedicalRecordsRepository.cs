using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalRecords.API.Models;

namespace MedicalRecords.API.Data
{
    public interface IMedicalRecordsRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<Box>> GetBoxes();
        Task<Box> GetBox(int id);
        Task<bool> BoxExists(long barcodeNum);
        Task<Box> CreateBox(Box box);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<IEnumerable<File>> GetFilesForBox(int boxId);
        // Task<File> GetFile(int id);
        Task<File> CreateFile(File file);
        // Task<IEnumerable<File>> GetFilesForBox(int id);
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int id);
        Task<IEnumerable<County>> GetCounties();
        Task<County> GetCounty(int id);
        Task<Client> GetClient(int id);
    }
}