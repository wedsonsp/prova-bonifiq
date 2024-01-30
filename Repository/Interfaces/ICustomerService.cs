using ProvaPub.Models;

namespace ProvaPub.Repository.Interfaces
{
    public interface ICustomerService
    {
        //CustomerList ListCustomers(int page);
        EntityList<Customer> ListCustomers(int page);

    }
}
