# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY GOCIPv1/*.csproj ./GOCIPv1/
RUN dotnet restore GOCIPv1/GOCIPv1.csproj

COPY GOCIPv1/. ./GOCIPv1/
RUN dotnet publish GOCIPv1/GOCIPv1.csproj -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish ./

ENTRYPOINT ["dotnet", "GOCIPv1.dll"]