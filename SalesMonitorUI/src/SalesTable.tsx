// SalesTable.tsx
import React from "react";
import { SaleCreatedEvent } from "./models/sale";

interface SalesTableProps {
  sales: SaleCreatedEvent[];
}

const SalesTable = ({ sales }: SalesTableProps) => {
  return (
    <div>
      <h2>Vendas em Tempo Real</h2>
      <table>
        <thead>
          <tr>
            <th>Número da Venda</th>
            <th>Data</th>
            <th>Cliente</th>
            <th>Agência</th>
            <th>Valor Total</th>
            <th>Descontos</th>
            <th>Status</th>
            <th>Itens</th>
          </tr>
        </thead>
        <tbody>
          {sales.map((sale) => (
            <tr key={sale.saleNumber}>
              <td>{sale.saleNumber}</td>
              <td>{new Date(sale.saleDate).toLocaleString()}</td>
              <td>{sale.consumer}</td>
              <td>{sale.agency}</td>
              <td>R$ {sale.totalValue.toFixed(2)}</td>
              <td>R$ {sale.discounts.toFixed(2)}</td>
              <td>{sale.status || "Criado"}</td>
              <td>
                <ul>
                  {sale.items.map((item, index) => (
                    <li key={index}>
                      {item.quantity}x {item.product} - R$ {item.totalValue.toFixed(2)} (Desconto: R$ {item.discount.toFixed(2)})
                    </li>
                  ))}
                </ul>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default SalesTable;
