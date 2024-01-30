#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SignalGrapher.API/SignalGrapher.API.csproj", "SignalGrapher.API/"]
COPY ["SignalGrapher.Application/SignalGrapher.Application.csproj", "SignalGrapher.Application/"]
COPY ["SignalGrapher.Domain/SignalGrapher.Domain.csproj", "SignalGrapher.Domain/"]
COPY ["SignalGrapher.Infrastructure/SignalGrapher.Infrastructure.csproj", "SignalGrapher.Infrastructure/"]
RUN dotnet restore "./SignalGrapher.API/./SignalGrapher.API.csproj"
COPY . .
WORKDIR "/src/SignalGrapher.API"
RUN dotnet build "./SignalGrapher.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SignalGrapher.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SignalGrapher.API.dll"]