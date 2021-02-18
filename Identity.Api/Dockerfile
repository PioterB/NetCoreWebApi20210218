#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Services/Identity/Api/FleetManagement.Services.Identity.Api.csproj", "Services/Identity/Api/"]
COPY ["Services/Identity/Domain/FleetManagement.Services.Identity.Domain.csproj", "Services/Identity/Domain/"]
COPY ["Utils/CreoCraft.Domain/CreoCraft.Domain.csproj", "Utils/CreoCraft.Domain/"]
RUN dotnet restore "Services/Identity/Api/FleetManagement.Services.Identity.Api.csproj"
COPY . .
WORKDIR "/src/Services/Identity/Api"
RUN dotnet build "FleetManagement.Services.Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FleetManagement.Services.Identity.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FleetManagement.Services.Identity.Api.dll"]
