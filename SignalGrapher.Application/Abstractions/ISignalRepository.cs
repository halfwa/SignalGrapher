using SignalGrapher.Domain.SinusoidalSignals;

namespace SignalGrapher.Application.Abstractions;

public interface ISignalRepository
{
    Task<SinusoidalSignal?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<Guid> InsertAsync(SinusoidalSignal signal, CancellationToken cancellationToken);
}
