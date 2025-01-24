using DeveloperStore.API.Models;
using System;
using System.Linq;

namespace DeveloperStore.API.Services
{
    public class SaleService
    {
        public Sale CalculateSale(Sale sale)
        {
            decimal totalAmount = 0;
            foreach (var item in sale.Items)
            {
                // Aplicando as regras de desconto conforme a quantidade
                if (item.Quantity >= 4 && item.Quantity <= 9)
                {
                    item.Discount = 0.10m;  // 10% de desconto
                }
                else if (item.Quantity >= 10 && item.Quantity <= 20)
                {
                    item.Discount = 0.20m;  // 20% de desconto
                }
                else
                {
                    item.Discount = 0m;  // Nenhum desconto
                }

                // Calculando o total por item
                item.TotalValue = item.Quantity * item.UnitPrice * (1 - item.Discount);
                totalAmount += item.TotalValue;
            }

            // Calculando o valor total da venda
            sale.TotalValue = totalAmount;
            return sale;
        }
    }
}
