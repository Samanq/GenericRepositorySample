using Microsoft.EntityFrameworkCore;
using GenericRepositorySample.Api.Entities;

namespace GenericRepositorySample.Api.DataContexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
}
