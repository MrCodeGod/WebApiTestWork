using Microsoft.EntityFrameworkCore;

namespace WebApiTestWork.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Games> propGames { get; set; }
}
