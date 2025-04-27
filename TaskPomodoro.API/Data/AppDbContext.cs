using Microsoft.EntityFrameworkCore;
using TaskPomodoro.API.Models;

namespace TaskPomodoro.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}