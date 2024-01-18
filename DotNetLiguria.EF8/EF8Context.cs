using DotNetLiguria.EF8.Configurations;
using DotNetLiguria.EF8.Conventions;
using DotNetLiguria.EF8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DotNetLiguria.EF8;

public class EF8Context : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder
        // attiva la registrazione dei dati sensibili
        //.EnableSensitiveDataLogging()

        // Imposta il comportamento di rilevamento predefinito per le query
        //.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)

        // Errori di query più dettagliati (a spesa delle prestazioni)
        //.EnableDetailedErrors()

        // Require the package "Microsoft.EntityFrameworkCore.Proxies" - viene abilitato il caricamento lazy per qualsiasi proprietà di navigazione che può essere sottoposta a override (virtual)
        //.UseLazyLoadingProxies()

            .UseSqlServer(
                @"Server=.;Database=EF8;Trusted_Connection=true;Encrypt=False", 
                x => x.UseHierarchyId()
            ).LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Conventions.Add(_ => new DiscriminatorLengthConvention());
        configurationBuilder.Conventions.Add(_ => new MaxStringLengthConvention());
    }
}
