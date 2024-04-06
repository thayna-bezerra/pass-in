using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure;

public class PassInDbContext : DbContext
{
    public DbSet<Event> Events { get; set; } //representa minha tabela eventos
    public DbSet<Attendee> Attendees { get; set; } // tabela participantes
    public DbSet<CheckIn> CheckIns { get; set; } // tabela checkin

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\User\\Documents\\GitHub\\Sites\\pass-in\\PassInDb.db");
    }
}
