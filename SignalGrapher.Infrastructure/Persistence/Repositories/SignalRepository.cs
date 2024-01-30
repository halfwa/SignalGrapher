using Microsoft.EntityFrameworkCore;
using SignalGrapher.Application.Abstractions;
using SignalGrapher.Domain.SinusoidalSignals;

namespace SignalGrapher.Infrastructure.Persistence.Repositories;

internal sealed class SignalRepository : ISignalRepository
{
    private readonly ApplicationDbContext _context;

    public SignalRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SinusoidalSignal?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var signal = await _context.SinusoidalSignals
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (signal is null)
        {
            throw new SinusoidalSignalNotFoundException(id);
        }

        return signal;
    }

    public async Task<Guid> InsertAsync(SinusoidalSignal signal, CancellationToken cancellationToken)
    {
        var signalEntity = await _context.SinusoidalSignals
           .AsNoTracking()
           .FirstOrDefaultAsync(x => x.Id == signal.Id, cancellationToken);

        if (signalEntity is not null)
        {
            throw new ArgumentException(nameof(signal.Id));
        }

        await _context.SinusoidalSignals.AddAsync(signal, cancellationToken);

        return signal.Id;    
    }
}
