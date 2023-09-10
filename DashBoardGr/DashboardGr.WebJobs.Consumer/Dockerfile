#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DashboardGr.WebJobs.Consumer/DashboardGr.WebJobs.Consumer.csproj", "DashboardGr.WebJobs.Consumer/"]
RUN dotnet restore "DashboardGr.WebJobs.Consumer/DashboardGr.WebJobs.Consumer.csproj"
COPY . .
WORKDIR "/src/DashboardGr.WebJobs.Consumer"
RUN dotnet build "DashboardGr.WebJobs.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DashboardGr.WebJobs.Consumer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DashboardGr.WebJobs.Consumer.dll"]