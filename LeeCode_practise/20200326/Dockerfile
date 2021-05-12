#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["20200326/2020_03_26.csproj", "20200326/"]
RUN dotnet restore "20200326/2020_03_26.csproj"
COPY . .
WORKDIR "/src/20200326"
RUN dotnet build "2020_03_26.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "2020_03_26.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "2020_03_26.dll"]