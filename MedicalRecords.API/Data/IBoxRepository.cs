using System.Threading.Tasks;
using MedicalRecords.API.Models;

namespace MedicalRecords.API.Data
{
    public interface IBoxRepository
    {
        Task<bool> BoxExists(long barcodeNum);
        Task<Box> CreateBox(Box box);
    }
}