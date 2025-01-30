# Desafio Ambev - Monitoramento de Vendas

Este projeto faz parte do **Desafio Ambev**, focado no **monitoramento de eventos de vendas**. Ele inclui:

- **sales-monitoring-ui (React)** → Interface para acompanhar eventos em tempo real.
- **SalesEventConsumer (.NET)** → API que consome eventos de vendas e os retransmite via SignalR.
- **RabbitMQ** → Message broker utilizado para comunicação entre os serviços.

## Tecnologias Utilizadas

- **.NET 8** com **MassTransit** e **SignalR**
- **React.js** com **WebSockets**
- **RabbitMQ** para mensageria
- **Docker** e **Docker Compose** para containerização

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
