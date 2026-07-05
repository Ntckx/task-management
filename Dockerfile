# Stage 1 — Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

COPY TaskManagement.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /publish

# Stage 2 — Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /publish .

ENTRYPOINT ["dotnet", "TaskManagement.dll"]