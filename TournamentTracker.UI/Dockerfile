#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TournamentTracker.UI/TournamentTracker.UI.csproj", "TournamentTracker.UI/"]
COPY ["TournamentTracker.Infrastructure/TournamentTracker.Infrastructure.csproj", "TournamentTracker.Infrastructure/"]
COPY ["TournamentTracker.Core/TournamentTracker.Core.csproj", "TournamentTracker.Core/"]
RUN dotnet restore "TournamentTracker.UI/TournamentTracker.UI.csproj"
COPY . .
WORKDIR "/src/TournamentTracker.UI"
RUN dotnet build "TournamentTracker.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TournamentTracker.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TournamentTracker.UI.dll"]