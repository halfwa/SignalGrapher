namespace SignalGrapher.Domain.SinusoidalSignals;

public sealed class SinusoidalSignalNotFoundException: Exception
{
    public SinusoidalSignalNotFoundException(Guid id)
         : base($"The signal with the ID = {id} was not found")
    {
    }
}
