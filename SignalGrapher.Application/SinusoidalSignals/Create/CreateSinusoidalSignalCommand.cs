using MediatR;

namespace SignalGrapher.Application.SinusoidalSignals.Create;

public sealed record CreateSinusoidalSignalCommand(
    Guid Id,
    double Amplitude,
    double SamplingFrequency,
    double SignalFrequency,
    int PeriodValue) : IRequest;
