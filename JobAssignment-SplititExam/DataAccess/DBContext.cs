using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccess
{
    public class DBContext : DbContext
    {
        public DbSet<ActorEntity> Actors { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ActorsDb");
        }
    }
}