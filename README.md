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

# Configuração e Execução do Projeto com Docker Compose

Este projeto utiliza **Docker Compose** para orquestrar múltiplos serviços, incluindo **RabbitMQ**, **PostgreSQL**, **Redis**, **MongoDB** e as aplicações backend e frontend. Como os serviços estão distribuídos em **diferentes docker-compose**, talvez seja necessário garantir que todos eles compartilhem a mesma **rede Docker** antes da execução.

---

## 🔧 **Configuração da Rede Docker**
Antes de rodar os containers, crie manualmente a **rede Docker** compartilhada para que todos os serviços possam se comunicar.


```sh
docker network create ambev_network
```

Se necessário, adicionar manualmente os conteineres após rodar o docker-compose de cada projeto:

```sh
docker network connect ambev_network ambev_developer_evaluation_webapi
docker network connect ambev_network ambev_developer_evaluation_database
docker network connect ambev_network rabbitmq
```


