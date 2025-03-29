# ReadMe d'instruction

  dotnet sonarscanner begin /k:"CbVitrineNet" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token="sqp_15b9bc307fdeab56b216ac5da70317c158d773e5"
  dotnet build
  dotnet sonarscanner end /d:sonar.token="sqp_15b9bc307fdeab56b216ac5da70317c158d773e5"