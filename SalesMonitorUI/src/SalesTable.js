import React, { useEffect, useState } from "react";
import * as signalR from "@microsoft/signalr";

const SalesTable = () => {
  const [sales, setSales] = useState([]);

  useEffect(() => {
    const backendUrl =
      window.location.hostname === "localhost"
        ? "http://localhost:5000/salesHub"
        : "http://sales-event-consumer:5000/salesHub";

    const connection = new signalR.HubConnectionBuilder()
      .withUrl(backendUrl)
      .withAutomaticReconnect()
      .build();

    connection.start()
      .then(() => console.log("Conectado ao SalesHub"))
      .catch(err => console.error("Erro na conexão: ", err));

    connection.on("ReceiveSaleCreated", (saleId, client, totalValue) => {
      setSales(prevSales => [...prevSales, { saleId, client, totalValue, status: "Created" }]);
    });

    connection.on("ReceiveSaleModified", (saleId, client, totalValue) => {
      setSales(prevSales =>
        prevSales.map(sale =>
          sale.saleId === saleId ? { ...sale, client, totalValue, status: "Modified" } : sale
        )
      );
    });

    connection.on("ReceiveSaleCanceled", (saleId) => {
      setSales(prevSales =>
        prevSales.map(sale =>
          sale.saleId === saleId ? { ...sale, status: "Canceled" } : sale
        )
      );
    });

    connection.on("ReceiveItemCanceled", (saleId, product) => {
      setSales(prevSales =>
        prevSales.map(sale =>
          sale.saleId === saleId ? { ...sale, status: `Item Canceled: ${product}` } : sale
        )
      );
    });

    return () => {
      connection.stop();
    };
  }, []);

  return (
    <div>
      <h2>Vendas em Tempo Real</h2>
      <table border="1">
        <thead>
          <tr>
            <th>ID da Venda</th>
            <th>Cliente</th>
            <th>Valor Total</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {sales.map((sale, index) => (
            <tr key={index}>
              <td>{sale.saleId}</td>
              <td>{sale.client}</td>
              <td>{sale.totalValue}</td>
              <td>{sale.status}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default SalesTable;
