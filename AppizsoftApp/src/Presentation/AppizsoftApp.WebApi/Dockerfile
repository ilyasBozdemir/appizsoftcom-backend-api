# Use the official .NET SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj file and restore any dependencies (NuGet)
COPY *.csproj ./
RUN dotnet restore

# Copy the entire project and build it
COPY . ./
RUN dotnet publish --no-restore -c Release -o out

# Use the official ASP.NET Core runtime image as the final base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Set the working directory in the container
WORKDIR /app

# Copy the published app from the build environment
COPY --from=build /app/out .

# Expose the port the app will run on
EXPOSE 80

# Define the command to run your .NET Core app
CMD ["dotnet", "AppizsoftApp.WebApi.dll"]
#

