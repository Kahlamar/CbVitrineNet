# ReadMe d'instruction


README en cours de rédaction.

Dans l'attente, voici les commandes dotnet à exécuter à la racine de la solution pour lancer une analyse via Sonarqube à l'url "http://localhost:9000".
Le container SonarQube doit fonctionner pour les lancer.

## Commandes SonarQube

```
  dotnet sonarscanner begin /k:"CbVitrineNet" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token=""
  dotnet build
  dotnet sonarscanner end /d:sonar.token=""
```