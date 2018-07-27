FROM microsoft/dotnet:2.1-sdk-alpine AS build
WORKDIR /app

# Copier le fichier projet et faire le restore
COPY *.csproj .
RUN dotnet restore

# Copier le code source et compiler l'applicatin
COPY . .
RUN dotnet publish -c Release -o out

# Création du conteneur final
FROM microsoft/dotnet:2.1-aspnetcore-runtime-stretch-slim AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT [ "dotnet", "Amf.Documentation.Developpement.API.dll" ]