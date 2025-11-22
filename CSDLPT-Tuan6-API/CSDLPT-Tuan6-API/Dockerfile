FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CSDLPT-Tuan6-API/CSDLPT-Tuan6-API.csproj", "CSDLPT-Tuan6-API/"]
RUN dotnet restore "CSDLPT-Tuan6-API/CSDLPT-Tuan6-API.csproj"
COPY . .
WORKDIR "/src/CSDLPT-Tuan6-API"
RUN dotnet build "./CSDLPT-Tuan6-API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CSDLPT-Tuan6-API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSDLPT-Tuan6-API.dll"]
