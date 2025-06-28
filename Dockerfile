# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Build image with SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files for all projects
COPY ["CollegeManagement.Context/CollegeManagement.Context.csproj", "CollegeManagement.Context/"]
COPY ["CollegeManagement.Repo/CollegeManagement.Repo.csproj", "CollegeManagement.Repo/"]
COPY ["CollegeManagement.Service/CollegeManagement.Service.csproj", "CollegeManagement.Service/"]
COPY ["CollegeMangementAPI/CollegeMangementAPI.csproj", "CollegeMangementAPI/"]

# Restore dependencies for the API project
RUN dotnet restore "CollegeMangementAPI/CollegeMangementAPI.csproj"

# Copy all files (source code)
COPY . .

# Set working directory to API project
WORKDIR "/src/CollegeMangementAPI"

# Build the API project
RUN dotnet build "CollegeMangementAPI.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "CollegeMangementAPI.csproj" -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose port (change if needed)
EXPOSE 80
ENV ASPNETCORE_URLS=http://*:80

# Run the API
ENTRYPOINT ["dotnet", "CollegeMangementAPI.dll"]
