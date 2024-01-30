using MediatR;
using SignalGrapher.Application.Abstractions;
using SignalGrapher.Domain.SinusoidalSignals;

namespace SignalGrapher.Application.SinusoidalSignals.Create;

internal sealed class CreateSinusoidalSignalCommandHandler : IRequestHandler<CreateSinusoidalSignalCommand>
{
    private readonly IPlotterService _plotterService;

    private readonly ISignalRepository _signalRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSinusoidalSignalCommandHandler(ISignalRepository signalRepository, IUnitOfWork unitOfWork, IPlotterService plotterService)
    {
        _plotterService = plotterService;

        _signalRepository = signalRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateSinusoidalSignalCommand request, CancellationToken cancellationToken)
    {
        var (signal, error) = SinusoidalSignal.Create(
            request.Id,
            DateTime.UtcNow,
            request.Amplitude,
            request.SignalFrequency,
            request.SignalFrequency,
            request.PeriodValue
            );

        if (!string.IsNullOrEmpty(error) || signal is null)
        {
            throw new ArgumentException(error);
        }

        await _plotterService.DrawPlotImage(signal);

        await _signalRepository.InsertAsync(signal, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken); 
    }
}
