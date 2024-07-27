using API_CRUD_USING_DB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_USING_DB.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public  DbSet<Employee> Employees { get; set; }
    }
}
