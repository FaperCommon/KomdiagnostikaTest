using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace DAL.Common
{
    public class AppDbContext : DbContext
    {
        internal DbSet<Store> Store { get; set; }

        public AppDbContext()
            : base()
        { }

        public AppDbContext(DbContextOptions options)
            : base(options)
        { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(/*inject connection string*/);
        //}
    }
}