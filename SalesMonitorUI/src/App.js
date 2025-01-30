import React, { useEffect, useState } from "react";
import * as signalR from "@microsoft/signalr";
import SalesTable from "./SalesTable";

function App() {
  const [sales, setSales] = useState([]);

  useEffect(() => {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl("http://localhost:5000/salesHub") // Ajuste para backend conforme necessário
      .withAutomaticReconnect()
      .build();

    connection.start()
      .then(() => console.log("Conectado ao SignalR"))
      .catch((err) => console.error("Erro na conexão:", err));

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
    <div className="App">
      <h1>Monitoramento de Vendas</h1>
      <SalesTable sales={sales} />
    </div>
  );
}

export default App;
