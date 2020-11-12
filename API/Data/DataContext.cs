using API.Entities;
using Microsoft.EntityFrameworkCore;

//2.12{
namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
    //}2.12
}
