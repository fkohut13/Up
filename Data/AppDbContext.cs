using Program.Models;
using Microsoft.EntityFrameworkCore;

namespace Programdata.Data
{
    public class AppDbContext : DbContext
    {
       
        public DbSet<Playlist> Playlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=program.sqlite;Cache=Shared");
    }
     
}