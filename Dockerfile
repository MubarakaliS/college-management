# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj from subfolder
COPY CollegeManagementAPI/CollegeManagementAPI.csproj ./CollegeManagementAPI/
WORKDIR /src/CollegeManagementAPI
RUN dotnet restore

# Copy the rest of the code
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "CollegeManagementAPI.dll"]
