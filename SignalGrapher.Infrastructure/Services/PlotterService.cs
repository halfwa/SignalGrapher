using ScottPlot;
using SignalGrapher.Application.Abstractions;
using SignalGrapher.Domain.SinusoidalSignals;

namespace SignalGrapher.Infrastructure.Services;

public sealed class PlotterService : IPlotterService
{

    public async Task DrawPlotImage(SinusoidalSignal signal)
    {
        Plot plt = new();

        var result = signal.GenerateSinusoidalSignal();

        plt.Add.SignalXY(result.Time, result.Amplitude, Colors.Red);
/*      plt.Axes.Left.Label.Text = "Amplitude";
        plt.Axes.Title.Label.Text = "Sinusoidal Signal";
        plt.Axes.Bottom.Label.Text = "Time (s)";
        plt.Legend.IsVisible = true;
        plt.ShowLegend(); */ 

        var path = Path.Combine(Directory.GetCurrentDirectory(), "statics", "images");

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        var filePath = Path.Combine(path, $"{signal.Id}.jpeg");
        plt.SaveJpeg(filePath, 800, 600);

        byte[] imageBytes;
        using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            imageBytes = new byte[fileStream.Length];
            await fileStream.ReadAsync(imageBytes, 0, (int)fileStream.Length);
        }
        File.Delete(filePath);

        signal.SetPlotImage(imageBytes);
    }
}
