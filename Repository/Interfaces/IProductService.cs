using ProvaPub.Models;

namespace ProvaPub.Repository.Interfaces
{
    public interface IProductService
    {
        //ProductList ListProducts(int page);
        //EntityList<Product> ListProducts(int page);
        EntityList<Product> ListProducts(int page);
    }
}
