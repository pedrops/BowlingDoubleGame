using BowlingGame.BE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.DA
{
    public class BowlingGameDBContext : DbContext
    {
        public BowlingGameDBContext(DbContextOptions<BowlingGameDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasKey(table => new {
                table.Id,
                table.GameSetupId
            });
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameSetup> GameSetups { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}

