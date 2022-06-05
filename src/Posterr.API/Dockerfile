#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Posterr.API/Posterr.API.csproj", "src/Posterr.API/"]
COPY ["src/Posterr.Application/Posterr.Application.csproj", "src/Posterr.Application/"]
COPY ["src/Posterr.Domain/Posterr.Domain.csproj", "src/Posterr.Domain/"]
RUN dotnet restore "src/Posterr.API/Posterr.API.csproj"
COPY . .
WORKDIR "/src/src/Posterr.API"
RUN dotnet build "Posterr.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Posterr.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

ENV CONNECTIONSTRINGS__DBCONNECTION="Server=localhost;Port=5432;Database=Posterr_db;User Id=postgres;Password=!P0st3r@"

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Posterr.API.dll"]