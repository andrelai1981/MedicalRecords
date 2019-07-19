using MedicalRecords.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalRecords.API.Data
{
    public class DataContext : DbContext    
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        
        public DbSet<Box> Boxes { get; set; }
        public DbSet<User> Users {get; set;}
        public DbSet<County> Counties {get; set;}
        public DbSet<Department> Departments { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}