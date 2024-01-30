using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalGrapher.Domain.SinusoidalSignals;

namespace SignalGrapher.Infrastructure.Persistence.Configurations;

internal class SinusoidalSignalConfiguration : IEntityTypeConfiguration<SinusoidalSignal>
{
    public void Configure(EntityTypeBuilder<SinusoidalSignal> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Amplitude).IsRequired();

        builder.Property(s => s.SamplingFrequency).IsRequired();

        builder.Property(s => s.SignalFrequency).IsRequired();

        builder.Property(s => s.PeriodValue).IsRequired();

        builder.Property(s => s.PlotImage).IsRequired()
            .HasMaxLength(SinusoidalSignal.MAX_IMAGE_SIZE);
    }
}
