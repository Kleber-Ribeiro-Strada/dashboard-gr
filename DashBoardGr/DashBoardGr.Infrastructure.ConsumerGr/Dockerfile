#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DashBoardGr.Infrastructure.ConsumerGr/DashBoardGr.Infrastructure.ConsumerGr.csproj", "DashBoardGr.Infrastructure.ConsumerGr/"]
RUN dotnet restore "DashBoardGr.Infrastructure.ConsumerGr/DashBoardGr.Infrastructure.ConsumerGr.csproj"
COPY . .
WORKDIR "/src/DashBoardGr.Infrastructure.ConsumerGr"
RUN dotnet build "DashBoardGr.Infrastructure.ConsumerGr.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DashBoardGr.Infrastructure.ConsumerGr.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DashBoardGr.Infrastructure.ConsumerGr.dll"]