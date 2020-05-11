
using Microsoft.EntityFrameworkCore;
using DataLayer.Model;
namespace DataLayer
{
    public class MyDBContext : DbContext
    {
        public DbSet<Speler> Spelers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-HK7G5H0N\SQLEXPRESS;Initial Catalog=League;Integrated Security=True");
        }
    }

}