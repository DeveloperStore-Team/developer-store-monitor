# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia e restaura as dependências
COPY ["SalesEventConsumer.csproj", "./"]
RUN dotnet restore

# Copia o código e compila a aplicação em Release para Linux
COPY . .
RUN dotnet publish -c Release -r linux-x64 --self-contained false -o /app/out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia os arquivos publicados da etapa de build
COPY --from=build /app/out . 

# Exibe os arquivos para debug
RUN ls -l /app

# Expõe as portas da aplicação
EXPOSE 5000
EXPOSE 5001

# Configuração para rodar em todas as interfaces
ENV ASPNETCORE_URLS="http://+:5000"

# Comando de entrada
ENTRYPOINT ["dotnet", "SalesEventConsumer.dll"]
