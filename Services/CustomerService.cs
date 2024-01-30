using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Services
{
    public class CustomerService: ICustomerService
    {
        private const int PageSize = 10; // Tamanho da página fixo em 10
        private readonly TestDbContext _ctx;

        public CustomerService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public EntityList<Customer> ListCustomers(int page)
        {
            // Calcula o índice de início da página
            int startIndex = (page - 1) * PageSize;

            // Obtém os produtos da página atual com base no tamanho da página
            var customers = _ctx.Customers.Skip(startIndex).Take(PageSize).ToList();

            // Verifica se existem mais páginas
            bool hasNext = _ctx.Customers.Skip(page * PageSize).Any();

            // Retorna a lista de produtos com os metadados de paginação
            return new EntityList<Customer>() { TotalCount = _ctx.Products.Count(), HasNext = hasNext, Items = customers };
        }

        public async Task<bool> CanPurchase(int customerId, decimal purchaseValue)
        {
            if (customerId <= 0) throw new ArgumentOutOfRangeException(nameof(customerId));

            if (purchaseValue <= 0) throw new ArgumentOutOfRangeException(nameof(purchaseValue));

            //Business Rule: Non registered Customers cannot purchase
            var customer = await _ctx.Customers.FindAsync(customerId);
            if (customer == null) throw new InvalidOperationException($"Customer Id {customerId} does not exists");

            //Business Rule: A customer can purchase only a single time per month
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            var ordersInThisMonth = await _ctx.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
            if (ordersInThisMonth > 0)
                return false;

            //Business Rule: A customer that never bought before can make a first purchase of maximum 100,00
            var haveBoughtBefore = await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());
            if (haveBoughtBefore == 0 && purchaseValue > 100)
                return false;

            return true;
        }

    }
}
