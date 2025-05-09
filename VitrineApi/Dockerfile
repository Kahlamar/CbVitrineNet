# Consultez https://aka.ms/customizecontainer pour savoir comment personnaliser votre conteneur de d�bogage et comment Visual�Studio utilise ce Dockerfile pour g�n�rer vos images afin d�acc�l�rer le d�bogage.

# Cet index est utilis� lors de l�ex�cution � partir de VS en mode rapide (par d�faut pour la configuration de d�bogage)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Cette phase est utilis�e pour g�n�rer le projet de service
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["VitrineApi/VitrineApi.csproj", "VitrineApi/"]
RUN dotnet restore "./VitrineApi/VitrineApi.csproj"
COPY . .
WORKDIR "/src/VitrineApi"
RUN dotnet build "./VitrineApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Cette �tape permet de publier le projet de service � copier dans la phase finale
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VitrineApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Cette phase est utilis�e en production ou lors de l�ex�cution � partir de VS en mode normal (par d�faut quand la configuration de d�bogage n�est pas utilis�e)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VitrineApi.dll"]