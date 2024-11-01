# Imagem base para o build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Define o diretório de trabalho dentro do container
WORKDIR /app

# Copia o arquivo csproj e restaura as dependências
COPY LigChat.csproj ./
RUN dotnet restore

# Copia o appsettings e o arquivo de configuração
COPY appsettings.Production.json ./appsettings.json

# Copia o restante dos arquivos da aplicação e compila
COPY . ./
RUN dotnet publish -c Release -o out

# Migrations
RUN dotnet ef database update

# Imagem base para o runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Define o diretório de trabalho dentro do container
WORKDIR /app

# Copia os arquivos compilados do estágio de build
COPY --from=build /app/out .

# Define a porta que a aplicação vai expor
EXPOSE 80

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "LigChat.dll"]
