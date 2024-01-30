using ProvaPub.Models;

namespace ProvaPub.Services.PaymentProcessors
{
    public interface IPaymentProcessor
    {
        Task<Order> ProcessoPagamento(decimal paymentValue, int customerId);

    }
}
