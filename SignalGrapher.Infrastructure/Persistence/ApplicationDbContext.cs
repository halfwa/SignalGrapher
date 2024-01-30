using SignalGrapher.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using SignalGrapher.Domain.SinusoidalSignals;

namespace SignalGrapher.Infrastructure.Persistence;

public class ApplicationDbContext: DbContext, IUnitOfWork
{
    public DbSet<SinusoidalSignal> SinusoidalSignals { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
