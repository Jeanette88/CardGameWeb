using CardGameWeb.Server.Configuration;
using CardGameWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CardGameWeb.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<CardGame> CardGames { get; set; }
        public DbSet<Hand> Hands { get; set; }
        public DbSet<CardHand> CardHands { get; set; }

    }
}