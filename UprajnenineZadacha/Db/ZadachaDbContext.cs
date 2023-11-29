using Microsoft.EntityFrameworkCore;
using UprajnenineZadacha.Models;

namespace UprajnenineZadacha.Db
{
    public class ZadachaDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseSqlServer("Server=GEORGI\\SQLEXPRESS;Database=UprajnenieDb;Trusted_Connection=True;TrustServerCertificate=True\r\n");

        }
    }
}
