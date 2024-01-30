using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;
using ProvaPub.Repository;
using System.Linq;

namespace ProvaPub.Services
{
    public class ProductService : IProductService
    {
        private const int PageSize = 10; // Tamanho da página fixo em 10
        private readonly TestDbContext _ctx;

        public ProductService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public EntityList<Product> ListProducts(int page)
        {
            // Calcula o índice de início da página
            int startIndex = (page - 1) * PageSize;

            // Obtém os produtos da página atual com base no tamanho da página
            var products = _ctx.Products.Skip(startIndex).Take(PageSize).ToList();

            // Verifica se existem mais páginas
            bool hasNext = _ctx.Products.Skip(page * PageSize).Any();

            // Retorna a lista de produtos com os metadados de paginação
            return new EntityList<Product>() { TotalCount = _ctx.Products.Count(), HasNext = hasNext, Items = products };
        }
    }
}


