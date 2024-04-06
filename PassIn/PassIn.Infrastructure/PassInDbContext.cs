using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure;

public class PassInDbContext : DbContext
{
    public DbSet<Event> Events { get; set; } //representa minha tabela eventos
    public DbSet<Attendee> Attendees { get; set; } // tabela participantes

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\User\\Documents\\GitHub\\Sites\\pass-in\\PassInDb.db");
    }
}
