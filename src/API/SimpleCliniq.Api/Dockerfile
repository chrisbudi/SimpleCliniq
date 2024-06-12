
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/API/SimpleCliniq.Api/SimpleCliniq.Api.csproj", "API/SimpleCliniq.Api/"]

COPY ["src/Common/SimpleCliniq.Common.Application/SimpleCliniq.Common.Application.csproj", "Common/SimpleCliniq.Common.Application/"]
COPY ["src/Common/SimpleCliniq.Common.Domain/SimpleCliniq.Common.Domain.csproj", "Common/SimpleCliniq.Common.Domain/"]
COPY ["src/Common/SimpleCliniq.Common.Infrastructure/SimpleCliniq.Common.Infrastructure.csproj", "Common/SimpleCliniq.Common.Infrastructure/"]
COPY ["src/Common/SimpleCliniq.Common.Presentation/SimpleCliniq.Common.Presentation.csproj", "Common/SimpleCliniq.Common.Presentation/"]

COPY ["src/Modules/Core/SimpleCliniq.Module.Core.Domain/SimpleCliniq.Module.Core.Domain.csproj", "Modules/Core/SimpleCliniq.Module.Core.Domain/"]
COPY ["src/Modules/Core/SimpleCliniq.Module.Core.Infrastructure/SimpleCliniq.Module.Core.Infrastructure.csproj", "Modules/Core/SimpleCliniq.Module.Core.Infrastructure/"]

RUN dotnet restore "./API/SimpleCliniq.Api/SimpleCliniq.Api.csproj"
COPY . .
WORKDIR "/src/API/SimpleCliniq.Api"
RUN dotnet build "./SimpleCliniq.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SimpleCliniq.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app	

USER root

COPY ./SimpleCliniq.Api/aspnetapp.pfx /app/aspnetapp.pfx

#RUN chmod 644 /app/
#RUN chown root:root /app/aspnetapp.pfx && chmod 644 /app/aspnetapp.pfx

ENV ASPNETCORE_Kestrel__Certificates__Default__Password=secret
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/aspnetapp.pfx


COPY --from=publish /app/publish .

RUN chmod -R 755 /app

ENTRYPOINT ["dotnet", "SimpleCliniq.Api.dll"]

#ENTRYPOINT ["dotnet", "SimpleCliniq.Api.dll"]
