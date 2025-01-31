export interface SaleItemEvent {
    product: string;
    quantity: number;
    price: number;
    totalValue: number;
    discount: number;
  }
  
  export interface SaleCreatedEvent {
    saleId: string;
    saleNumber: string;
    saleDate: string;
    consumer: string;
    agency: string;
    totalValue: number;
    discounts: number;
    items: SaleItemEvent[];
    status?: string;
  }
  