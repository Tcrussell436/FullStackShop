FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FullStackShop.API/FullStackShop.API.csproj", "FullStackShop.API/"]
COPY ["FullStackShop.EF/FullStackShop.EF.csproj", "FullStackShop.EF/"]
COPY ["FullStackShop.Domain/FullStackShop.Domain.csproj", "FullStackShop.Domain/"]
RUN dotnet restore "FullStackShop.API/FullStackShop.API.csproj"
COPY . .
WORKDIR "/src/FullStackShop.API"
RUN dotnet build "FullStackShop.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FullStackShop.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
COPY FullStackShop.API/fssapi.pfx /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FullStackShop.API.dll"]
