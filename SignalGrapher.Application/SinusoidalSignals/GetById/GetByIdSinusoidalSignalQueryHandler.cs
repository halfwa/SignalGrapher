using MediatR;
using SignalGrapher.Application.Abstractions;

namespace SignalGrapher.Application.SinusoidalSignals.GetById;

internal sealed class GetByIdSinusoidalSignalQueryHandler : IRequestHandler<GetByIdSinusoidalSignalQuery, SinusoidalSignalResponse>
{
    private readonly ISignalRepository _signalRepository;

    public GetByIdSinusoidalSignalQueryHandler(ISignalRepository signalRepository)
    {
        _signalRepository = signalRepository;
    }

    public async Task<SinusoidalSignalResponse> Handle(GetByIdSinusoidalSignalQuery request, CancellationToken cancellationToken)
    {
        var signal = await _signalRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        var response = new SinusoidalSignalResponse(signal!.PlotImage);

        return response;
    }
}
