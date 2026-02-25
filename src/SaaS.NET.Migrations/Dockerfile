FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SaaS.NET.Migrations/SaaS.NET.Migrations.csproj", "src/SaaS.NET.Migrations/"]
RUN dotnet restore "src/SaaS.NET.Migrations/SaaS.NET.Migrations.csproj"
COPY . .
WORKDIR "/src/src/SaaS.NET.Migrations"
RUN dotnet build "./SaaS.NET.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SaaS.NET.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SaaS.NET.Migrations.dll"]
