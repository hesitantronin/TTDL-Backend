# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
LABEL maintainer="Ronin van Egdom studNr.(1053927)"
LABEL description="This image contains the backend/API of the TTDL software package"
LABEL version="version1.0"

WORKDIR /app
COPY . .
RUN dotnet restore "TTDL-Backend.csproj"
RUN dotnet build "TTDL-Backend.csproj" -c Release -o /app/build
RUN dotnet publish "TTDL-Backend.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TTDL-Backend.dll"]
