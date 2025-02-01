# Desafio Ambev - Monitoramento de Vendas

Este projeto faz parte do **Desafio Ambev**, focado no **monitoramento de eventos de vendas**. Ele inclui:

- **sales-monitoring-ui (React)** → Interface para acompanhar eventos em tempo real.
- **SalesEventConsumer (.NET)** → API que consome eventos de vendas e os retransmite via SignalR.
  
A proposta deste segundo projeto é acompanhar em tempo real as ocorrências relacionados a Venda; a fim de testar os recursos de messaging e eventos.

## 📌 Tecnologias Utilizadas
- Backend: .NET Core 8, MassTransit, RabbitMQ e SignalR.
- Frontend: React.js
- Mensageria: RabbitMQ
- Banco de Dados: PostgreSQL
- Docker e Docker-Compose para orquestração dos containers.

## 📡 Configuração de Redes e Portas para rodar no Docker
Os serviços utilizam a rede `ambev_network`, que deve ser criada antes de rodar os `docker-compose`. Abaixo estão as portas principais de cada serviço:

- **Backend (.NET)**
  - API de vendas
  - Porta: `8080 (HTTP)`, `8081 (HTTPS)`

- **Frontend (React)**
  - Interface de monitoramento em tempo real
  - Porta: `3000`

Certifique-se de que essas portas não estejam ocupadas antes de iniciar a aplicação. 🚀

## Como Rodar o Projeto

1. Clone o repositório:
   ```sh
   git clone https://github.com/DeveloperStore-Team/developer-store-monitor.git
   cd developer-store-monitor

2. 📌 Executando o Docker Compose**
O projeto inclui um **docker-compose.yml** para facilitar a configuração dos serviços.  
Para subir toda a infraestrutura (API, Banco de Dados, RabbitMQ, Consumer e Frontend), execute:

```sh
docker-compose up -d
