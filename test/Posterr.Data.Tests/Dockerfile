#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["test/Posterr.Data.Tests/Posterr.Data.Tests.csproj", "test/Posterr.Data.Tests/"]
COPY ["src/Posterr.Data.Shared/Posterr.Data.Shared.csproj", "src/Posterr.Data.Shared/"]
COPY ["src/Posterr.Domain/Posterr.Domain.csproj", "src/Posterr.Domain/"]
COPY ["src/Posterr.Data.Postgresql/Posterr.Data.Postgresql.csproj", "src/Posterr.Data.Postgresql/"]

RUN dotnet restore "test/Posterr.Data.Tests/Posterr.Data.Tests.csproj"
COPY . .
WORKDIR "/src/test/Posterr.Data.Tests"

RUN dotnet build "Posterr.Data.Tests.csproj" -c Release -o /app/build

ENTRYPOINT ["dotnet", "test"]