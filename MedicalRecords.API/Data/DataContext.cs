using MedicalRecords.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalRecords.API.Data
{
    public class DataContext : DbContext    
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        
        public DbSet<Box> Box { get; set; }
        public DbSet<County> County { get; set; }
    }
}