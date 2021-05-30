using Microsoft.EntityFrameworkCore;
using RestApi.DataAccess.Entities;

namespace RestApi.DataAccess
{
    public  class DataContext:DbContext

    {
        public DbSet<Entity> Entities { get; set; }
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}