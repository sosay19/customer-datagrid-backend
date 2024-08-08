# Use the official .NET runtime image as a base image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file and restore any dependencies
COPY ["customer-datagrid-backend.csproj", "./"]
RUN dotnet restore "./customer-datagrid-backend.csproj"

# Copy the remaining source code and build the project
COPY . .
WORKDIR "/src"
RUN dotnet build "customer-datagrid-backend.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "customer-datagrid-backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Define the entry point for the application
ENTRYPOINT ["dotnet", "customer-datagrid-backend.dll"]

# Set the environment variable for ASP.NET Core
ENV ASPNETCORE_ENVIRONMENT=Production
