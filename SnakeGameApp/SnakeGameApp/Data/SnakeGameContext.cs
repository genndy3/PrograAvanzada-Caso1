using Microsoft.EntityFrameworkCore;
using SnakeGameApp.Models;

namespace SnakeGameApp.Data
{
    public class SnakeGameContext : DbContext
    {
        public SnakeGameContext(DbContextOptions<SnakeGameContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Partida> Partidas { get; set; } 
    }
}