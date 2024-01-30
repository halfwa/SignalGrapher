namespace SignalGrapher.API.Contracts
{
    public sealed record CreateSinusoidalSignalRequest(
        double Amplitude,
        double SamplingFrequency,   
        double SignalFrequency,
        int PeriodValue);
}
