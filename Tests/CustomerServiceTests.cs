using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using Xunit;

namespace ProvaPub.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task CanPurchase()
        {
            // Arrange
            var customerId = -1; // Definindo um ID inválido
            var purchaseValue = 50; // Valor de compra válido
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            using var context = new TestDbContext(options); // Criando uma instância real do contexto de banco de dados em memória
            var customerService = new CustomerService(context); // Instância do serviço de cliente com o contexto de banco de dados em memória

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await customerService.CanPurchase(customerId, purchaseValue));
        }


    }
}

