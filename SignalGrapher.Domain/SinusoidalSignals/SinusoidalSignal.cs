namespace SignalGrapher.Domain.SinusoidalSignals
{

    public sealed class SinusoidalSignal
    {
        private const double PI = Math.PI;
        public const int MAX_IMAGE_SIZE = 5242880;

        private SinusoidalSignal(
            Guid id,
            DateTime createdTime,
            double amplitude,
            double samplingFrequency,
            double signalFrequency,
            int periodValue)
        {
            Id = id;
            CreatedTime = createdTime;
            Amplitude = amplitude;
            SamplingFrequency = samplingFrequency;
            SignalFrequency = signalFrequency;
            PeriodValue = periodValue;
        }

        private SinusoidalSignal()
        {
        }

        public Guid Id { get; private init; }

        public DateTime CreatedTime { get; private init; }

        public double Amplitude { get; private set; }

        public double SamplingFrequency { get; private set; }

        public double SignalFrequency { get; private set; }

        public int PeriodValue { get; private set; }

        public byte[] PlotImage { get; private set; } = null!;

        public byte[] SetPlotImage(byte[] image) => PlotImage = image;

        public static (SinusoidalSignal? Signal, string Error) Create(
            Guid id,
            DateTime createdTime,
            double amplitude,
            double samplingFrequency,
            double signalFrequency,
            int periodValue)
        {
            var error = string.Empty;

            if (amplitude <= 0 || samplingFrequency <= 0 ||
                signalFrequency <= 0 || periodValue <= 0)
            {
                error = "Incorrect input. Value should be more then 0. Try again";
            }

            var signal = new SinusoidalSignal(
                id,
                createdTime,
                amplitude,
                samplingFrequency,
                signalFrequency,
                periodValue);

            return (signal, error);
        }

        public double[] GenerateSinusoidalSignal()
        {
            int totalSamples = (int)(SamplingFrequency * PeriodValue);
            double[] signal = new double[totalSamples];

            for (int i = 0; i < totalSamples; i++)
            {
                double t = i / SamplingFrequency;
                signal[i] = Amplitude * Math.Sin(2 * PI * SignalFrequency * t);
            }

            return signal;
        }
    }
}