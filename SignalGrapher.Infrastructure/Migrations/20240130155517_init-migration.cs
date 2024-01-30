using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalGrapher.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SinusoidalSignals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amplitude = table.Column<double>(type: "double precision", nullable: false),
                    SamplingFrequency = table.Column<double>(type: "double precision", nullable: false),
                    SignalFrequency = table.Column<double>(type: "double precision", nullable: false),
                    PeriodValue = table.Column<int>(type: "integer", nullable: false),
                    PlotImage = table.Column<byte[]>(type: "bytea", maxLength: 5242880, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinusoidalSignals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinusoidalSignals");
        }
    }
}
