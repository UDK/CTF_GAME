#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 8098 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CTF_GAME.csproj", "./"]
RUN dotnet restore "CTF_GAME.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "CTF_GAME.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CTF_GAME.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CTF_GAME.dll"]
