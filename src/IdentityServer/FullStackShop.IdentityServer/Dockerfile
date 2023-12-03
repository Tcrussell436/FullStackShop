FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FullStackShop.IdentityServer/FullStackShop.IdentityServer.csproj", "FullStackShop.IdentityServer/"]
RUN dotnet restore "FullStackShop.IdentityServer/FullStackShop.IdentityServer.csproj"
COPY . .
WORKDIR "/src/FullStackShop.IdentityServer"
RUN dotnet build "FullStackShop.IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FullStackShop.IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FullStackShop.IdentityServer.dll"]
