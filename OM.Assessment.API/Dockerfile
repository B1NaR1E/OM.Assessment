FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OM.Assessment.API/OM.Assessment.API.csproj", "OM.Assessment.API/"]
RUN dotnet restore "OM.Assessment.API/OM.Assessment.API.csproj"
COPY . .
WORKDIR "/src/OM.Assessment.API"
RUN dotnet build "OM.Assessment.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OM.Assessment.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OM.Assessment.API.dll"]
