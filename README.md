# CbVitrineNet

**Bienvenu sur ma Vitrine .Net! (en cours de développement)**

Vous trouverez dans la solution ici présente plusieurs projets:
- Le frontend Blazor principal avec une surcouche de composants visuels Radzen
- Le projet de classes C# permettant la déserialisation du JSON renvoyé par l'API
- La bibliothèque de composants Blazor afin de ne pas surcharger le projet Blazor principal
- Un projet de tests de BDD afin de ne pas les faire à la main via SSMS ou autre outil
- Un projet de tests fonctionnels sous Playwright
- Un projet de tests unitaires pour l'API
- Le projet d'API ASP .Net

## Lancement

La lancement de la solution requiert l'installation de Docker desktop. [Lien téléchargement](https://www.docker.com/products/docker-desktop/)
:a commande suivante doit être utilisée à la racine de la solution:
```
docker compose up [--build]
```

De plus, la base de données MongoDB sera remplie dès le premier lancement du container de l'API.

## Accès

| Élément         | URL par l'hôte      | container & port          | Commentaire                                                                                                                                    |
| --------------- | ------------------- | ------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| Frontend Blazor | **localhost:5000**  | **cbvitrinenet:8080**     | Accès principal à la vitrine                                                                                                                   |
| API ASP         | **localhost:5001**  | **vitrineapi:8080**       | Accès à l'API. L'accès via le navigateur renvoie "Démarrage API OK" sur "/". Testable via Postman (voir la collection dans VitrineAPI/Postman) |
| SQL Server      | **localhost:5002**  | **sqlservervitrine:1433** | Le port a été volontairement changé pour éviter les conflits avec les instances "en dur"                                                       |
| MongoDB         | **localhost:27017** | **mongodb:27017**         | L'accès se fait via les outils classiques                                                                                                      |
| Redis           | **localhost:6379**  | **redis:6379**            | En cours de développement                                                                                                                      |
| Sonarqube       | **localhost:9000**  | **sonarqube:9000**        | Accès à un serveur Sonarqube local                                                                                                             |
| PostgreSQL      |                     |                           | Utilisé uniquement pour Sonarqube                                                                                                             |

Le fichier **docker-compose.yml** est à la racine de la solution si vous voulez y jeter un œil.

## Docker

J'ai conteneurisé l'application à des fins de compatibilité et d'isolation.
En effet, un utilisateur pourrait avoir des instances en cours d'utilisation sur sa machine avec les ports par défauts ou autre.

Chaque projet "lançable" possède un Dockerfile à leurs racines.
Exemple généré via Visual Studio:

```
# Cet index est utilisé lors de l’exécution à partir de VS en mode rapide (par défaut pour la configuration de débogage)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Cette phase est utilisée pour générer le projet de service
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["VitrineApi/VitrineApi.csproj", "VitrineApi/"]
RUN dotnet restore "./VitrineApi/VitrineApi.csproj"
COPY . .
WORKDIR "/src/VitrineApi"
RUN dotnet build "./VitrineApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Cette étape permet de publier le projet de service à copier dans la phase finale
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VitrineApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Cette phase est utilisée en production ou lors de l’exécution à partir de VS en mode normal (par défaut quand la configuration de débogage n’est pas utilisée)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VitrineApi.dll"]
```

## Documentation

J'ai utilisé l'utilitaire [Doxygen](http://doxygen.nl/index.html) pour la génération de documentations.
Par convention, les commentaires démarrant par **\\\** sont les points d'entrées pour l'analyse Doxygen.

Le logiciel [Doxywizard](https://www.doxygen.nl/download.html) est le générateur de documentation.
Vous trouverez à la racine de la solution le fichier **Doxyfile** contenant les paramètres pour l'analyse (notamment l'ISO-8859-1 pour la prise en charge des accents)

Si vous voulez générer la documentation, suivez les étapes suivantes:
1. Ouvrez le **Doxywizard**
2. Fournissez le Doxyfile présent à la racine du projet ce qui remplira les param;tres
3. Fournissez le path de la racine de la solution (Source code directory)
4. Fournissez aussi le path de destination (Destination directory)
5. Cliquez sur l'onglet **Run** puis sur **Run doxygen**. Cela lancera l'analyse et générera la documentation en HTML navigable.  

Si le cœur vous en dit vous pouvez aussi déployer localement la documentation sur **IIS**. 


## Testing (en cours de développement)

### Base de données 

Afin d'éviter les exécutions de procédures stockées à la main ou via SSMS ou autres, j'ai créé un projet de tests.
Ces tests permettront de lancer des INSERT, DELETE etc...

### Tests Unitaires

Le projet **TestsUnitaires** contient les TU de l'API.
Le point d'entrée sera le service en question qui agira sur la BDD de destination.

### Tests Fonctionnels

Le projet **TestsFoncPW** contient les tests fonctionnels utilisant le framework Playwright.
**Attention, l'application doit fonctionner dans le container si vous voulez lancer les tests directement avec Visual Studio via l'explorateur de tests.**

### http

Le fichier **VitrineApi.http** est utilisé pour requêter l'API.

### Postman

Vous pouvez tester l'API via Postman en important la collection présente dans le dossier VitrineAPI/Postman.
Cette dernière est calibrée pour requêter sur l'API via **localhost:5001** de la machine hôte pour atteindre le conteneur **vitrineapi:8080**.

### Sonarqube

Si vous voulez accéder au serveur Sonarqube conteneurisé, accédez-y via **localhost:9000** à partir d'un navigateur.
Sonar vous demandera de changer le mot de passe admin, le choix du mot de passe est à votre discrétion.

Le lancement du scanner se fera via l'interface graphique qui vous indiquera la marche à suivre.
Le résumé des commandes est néanmoins celui-ci:

```
  dotnet sonarscanner begin /k:"CbVitrineNet" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token=""
  dotnet build
  dotnet sonarscanner end /d:sonar.token=""
```
