using SignalGrapher.Domain.SinusoidalSignals;

namespace SignalGrapher.Application.Abstractions;


public interface IPlotterService
{
    Task DrawPlotImage(SinusoidalSignal signal);
}
