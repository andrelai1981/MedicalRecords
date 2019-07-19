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
        Task<IEnumerable<Department>> GetDepartments();
        Task<IEnumerable<County>> GetCounties();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}