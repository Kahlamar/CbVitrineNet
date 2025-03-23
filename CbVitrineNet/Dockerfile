FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY CbVitrineNet/CbVitrineNet.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish CbVitrineNet.sln -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 5000
ENTRYPOINT ["dotnet", "CbVitrineNet.dll"]