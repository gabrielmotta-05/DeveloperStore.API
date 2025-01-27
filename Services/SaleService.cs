using DeveloperStore.API.Models;
using Microsoft.Extensions.Logging;

namespace DeveloperStore.API.Services
{
    public class SaleService
    {
        private readonly ILogger<SaleService> _logger;

        public SaleService(ILogger<SaleService> logger)
        {
            _logger = logger;
        }

        public Sale CalculateSale(Sale sale)
        {
            _logger.LogInformation("Iniciando cálculo de venda.");

            // Validar se a venda possui itens
            if (sale.Items == null || !sale.Items.Any())
            {
                _logger.LogWarning("A venda não contém itens.");
                throw new InvalidOperationException("A venda deve conter ao menos um item.");
            }

            decimal totalValue = 0;
            decimal totalDiscount = 0;

            foreach (var item in sale.Items)
            {
                // Calcular o valor total do item
                item.TotalValue = item.Quantity * item.UnitPrice;

                if (item.Quantity >= 4 && item.Quantity <= 9)
                {
                    item.Discount = item.TotalValue * 0.10m; // 10% de desconto
                    _logger.LogInformation($"Desconto de 10% aplicado no item {item.ProductId}.");
                }
                else if (item.Quantity >= 10 && item.Quantity <= 20)
                {
                    item.Discount = item.TotalValue * 0.20m; // 20% de desconto
                    _logger.LogInformation($"Desconto de 20% aplicado no item {item.ProductId}.");
                }
                else if (item.Quantity > 20)
                {
                    throw new InvalidOperationException("Não é possível vender mais de 20 itens de um mesmo produto.");
                }
                else
                {
                    item.Discount = 0;
                }


                // Acumular os valores
                totalValue += item.TotalValue;
                totalDiscount += item.Discount;
            }

            // Calcular o valor total da venda
            sale.TotalValue = totalValue - totalDiscount;
            sale.Discount = totalDiscount;

            _logger.LogInformation($"Venda calculada com sucesso. Total: {sale.TotalValue}, Desconto total: {sale.Discount}");

            return sale;
        }
    }
}
