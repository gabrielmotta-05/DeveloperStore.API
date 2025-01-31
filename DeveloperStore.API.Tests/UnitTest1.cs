using Xunit;
using Moq;
using DeveloperStore.API.Services;
using DeveloperStore.API.Models;

namespace DeveloperStore.API.Tests
{
    public class SaleServiceTests
    {
        private readonly SaleService _saleService;
        private readonly Mock<ILogger<SaleService>> _loggerMock;

        public SaleServiceTests()
        {
            _loggerMock = new Mock<ILogger<SaleService>>();
            _saleService = new SaleService(_loggerMock.Object);
        }

        [Fact]
        public void CalculateSale_DeveLancarExcecao_QuandoNaoHouverItens()
        {
            // Arrange
            var sale = new Sale { Items = new List<SaleItem>() };

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => _saleService.CalculateSale(sale));
            Assert.Equal("A venda deve conter ao menos um item.", exception.Message);
        }

        [Fact]
        public void CalculateSale_DeveAplicarDescontoDe10PorCento_QuandoQuantidadeEntre4e9()
        {
            // Arrange
            var sale = new Sale
            {
                Items = new List<SaleItem>
                {
                    new SaleItem { ProductId = 1, Quantity = 5, UnitPrice = 100 }
                }
            };

            // Act
            var result = _saleService.CalculateSale(sale);

            // Assert
            Assert.Equal(500m, sale.Items[0].TotalValue);
            Assert.Equal(50m, sale.Items[0].Discount); // 10% de 500
            Assert.Equal(450m, sale.TotalValue); // Total menos desconto
        }

        [Fact]
        public void CalculateSale_DeveAplicarDescontoDe20PorCento_QuandoQuantidadeEntre10e20()
        {
            // Arrange
            var sale = new Sale
            {
                Items = new List<SaleItem>
                {
                    new SaleItem { ProductId = 2, Quantity = 10, UnitPrice = 200 }
                }
            };

            // Act
            var result = _saleService.CalculateSale(sale);

            // Assert
            Assert.Equal(2000m, sale.Items[0].TotalValue);
            Assert.Equal(400m, sale.Items[0].Discount); // 20% de 2000
            Assert.Equal(1600m, sale.TotalValue);
        }

        [Fact]
        public void CalculateSale_DeveLancarExcecao_QuandoQuantidadeMaiorQue20()
        {
            // Arrange
            var sale = new Sale
            {
                Items = new List<SaleItem>
                {
                    new SaleItem { ProductId = 3, Quantity = 25, UnitPrice = 50 }
                }
            };

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => _saleService.CalculateSale(sale));
            Assert.Equal("Não é possível vender mais de 20 itens de um mesmo produto.", exception.Message);
        }
    }
}
