FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# When build context is the ApiGateway folder
COPY *.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:5005
ENV ASPNETCORE_ENVIRONMENT=Docker
EXPOSE 5005
COPY --from=build /app/publish/ .
ENTRYPOINT ["dotnet", "ApiGateway.dll"]
