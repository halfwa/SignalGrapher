using MediatR;

namespace SignalGrapher.Application.SinusoidalSignals.GetById;

public sealed record GetByIdSinusoidalSignalQuery(
    Guid Id): IRequest<SinusoidalSignalResponse>;


public sealed record SinusoidalSignalResponse(
    byte[] ImageBytes) : IRequest;