using BlazorCrud.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }
    
    public DbSet<Game> Games { get; set; }
}