
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project file(s) and restore
COPY WeatherAPI/WeatherAPI.csproj WeatherAPI/
RUN dotnet restore WeatherAPI/WeatherAPI.csproj

# Copy source and publish
COPY WeatherAPI/ WeatherAPI/
RUN dotnet publish WeatherAPI/WeatherAPI.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:5001
EXPOSE 5001
COPY --from=build /app/publish/ .
ENTRYPOINT ["dotnet", "WeatherAPI.dll"]
