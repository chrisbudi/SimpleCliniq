#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SimpleCliniq.Api/SimpleCliniq.Api.csproj", "SimpleCliniq.Api/"]
COPY ["SimpleCliniq.Module.Core.Domain/SimpleCliniq.Module.Core.Domain.csproj", "SimpleCliniq.Module.Core.Domain/"]
COPY ["SimpleCliniq.Module.Core.Infrastructure/SimpleCliniq.Module.Core.Infrastructure.csproj", "SimpleCliniq.Module.Core.Infrastructure/"]
RUN dotnet restore "./SimpleCliniq.Api/SimpleCliniq.Api.csproj"
COPY . .
WORKDIR "/src/SimpleCliniq.Api"
RUN dotnet build "./SimpleCliniq.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SimpleCliniq.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
	
COPY ${HOME}/.aspnet/https/aspnetapp.pfx /root/.aspnet/https/aspnetapp.pfx

# Set environment variables for the HTTPS certificate
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=secret
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/root/.aspnet/https/aspnetapp.pfx


RUN dotnet dev-certs https
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleCliniq.Api.dll"]