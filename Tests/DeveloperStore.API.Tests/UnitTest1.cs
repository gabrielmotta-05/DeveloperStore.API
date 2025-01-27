using DeveloperStore.API.Controllers;
using DeveloperStore.API.Models;
using DeveloperStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;

namespace DeveloperStore.API.Tests
{
    public class SaleControllerTests
    {
        private readonly Mock<SaleService> _saleServiceMock;
        private readonly SaleController _controller;

        public SaleControllerTests()
        {
            // Mocking the SaleService
            _saleServiceMock = new Mock<SaleService>();

            // Initialize the controller with the mocked service
            _controller = new SaleController(null, _saleServiceMock.Object);
        }

        [Fact]
        public async Task CreateSale_ShouldReturnCreatedResult_WhenSaleIsValid()
        {
            // Arrange: Create a valid Sale object
            var sale = new Sale
            {
                Customer = "Test Customer",
                SaleDate = System.DateTime.Now,
                TotalValue = 100,
                Items = new List<SaleItem>
                {
                    new SaleItem { ProductId = 1, Quantity = 2, UnitPrice = 50, Discount = 0 }
                }
            };

            // Arrange: Simulate the behavior of CalculateSale (returning the same sale object)
            _saleServiceMock.Setup(service => service.CalculateSale(It.IsAny<Sale>())).Returns(sale);

            // Act: Call the controller's CreateSale method
            var result = await _controller.CreateSale(sale);

            // Assert: Ensure the result is a CreatedAtActionResult
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdResult.StatusCode);
        }
    }
}
