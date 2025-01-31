// App.tsx
import React, { useEffect, useState } from "react";
import * as signalR from "@microsoft/signalr";
import SalesTable from "./SalesTable";
import { SaleCreatedEvent } from "./models/sale";

const App: React.FC = () => {
  const [sales, setSales] = useState<SaleCreatedEvent[]>([]);

  useEffect(() => {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl("http://localhost:5000/salesHub")
      .withAutomaticReconnect()
      .build();

    connection.start()
      .then(() => console.log("Conectado ao SignalR"))
      .catch((err) => console.error("Erro na conexão:", err));

    connection.on("ReceiveSaleCreated", (sale: SaleCreatedEvent) => {
      console.log("Nova venda recebida:", sale);
      setSales((prevSales) => [...prevSales, { ...sale, status: "Criado" }]);
    });

    connection.on("ReceiveSaleModified", (updatedSale: SaleCreatedEvent) => {
      console.log("Venda modificada:", updatedSale);
      setSales((prevSales) =>
        prevSales.map((sale) =>
          sale.saleId === updatedSale.saleId ? { ...updatedSale, status: "Modificado" } : sale
        )
      );
    });

    connection.on("ReceiveSaleCanceled", (saleId: string) => {
      console.log("Venda cancelada:", saleId);
      setSales((prevSales) =>
        prevSales.map((sale) =>
          sale.saleId === saleId ? { ...sale, status: "Cancelado" } : sale
        )
      );
    });

    connection.on("ReceiveItemCanceled", (saleId: string, product: string) => {
      console.log("Item cancelado:", saleId, product);
      setSales((prevSales) =>
        prevSales.map((sale) =>
          sale.saleId === saleId ? { ...sale, status: `Item Cancelado: ${product}` } : sale
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
};

export default App;
