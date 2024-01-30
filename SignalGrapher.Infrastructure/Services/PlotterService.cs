using ScottPlot;
using SignalGrapher.Application.Abstractions;
using SignalGrapher.Domain.SinusoidalSignals;

namespace SignalGrapher.Infrastructure.Services;

public sealed class PlotterService : IPlotterService
{

    public async Task DrawPlotImage(SinusoidalSignal signal)
    {
        Plot myPlot = new();

        myPlot.Add.Signal(signal.GenerateSinusoidalSignal());

        myPlot.XLabel("Horizonal Axis");
        myPlot.YLabel("Vertical Axis");
        myPlot.Title("Sinusoidal Signal");

        var path = Path.Combine(Directory.GetCurrentDirectory(), "statics", "images");
        Directory.CreateDirectory(path);

        var filePath = Path.Combine(path, $"{signal.Id}.png");
        myPlot.SavePng(filePath, 800, 600);

        byte[] imageBytes;
        using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            imageBytes = new byte[fileStream.Length];
            await fileStream.ReadAsync(imageBytes, 0, (int)fileStream.Length);
        }

        Directory.Delete(path, true);

        signal.SetPlotImage(imageBytes);
    }
}
