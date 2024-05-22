# Build application using dotnet SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Metadata
LABEL maintainer="Ronin van Egdom studNr.(1053927)"
LABEL description="This image contains the backend/API of the TTDL software package"
LABEL version="version1.0"

# Set working directory inside the container
WORKDIR /app
# Copy all files from current directory to /app inside the container
COPY . .

# Restore, Build and Publish the app to the container
RUN dotnet restore "TTDL-Backend.csproj"
RUN dotnet build "TTDL-Backend.csproj" -c Release -o /app/build
RUN dotnet publish "TTDL-Backend.csproj" -c Release -o /app/publish

# Using the dotnet runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
# Set working directory inside container
WORKDIR /app
# Copy the result of the publish from the build stage to the working dir
COPY --from=build /app/publish .
# Run application
ENTRYPOINT ["dotnet", "TTDL-Backend.dll"]
