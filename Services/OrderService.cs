using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services.PaymentProcessors;
using System;

namespace ProvaPub.Services
{
    public class OrderService
    {
        private readonly TestDbContext _ctx;
        public OrderService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            IPaymentProcessor paymentProcessor;

            // Seleciona o processador de pagamento com base no método de pagamento fornecido
            switch (paymentMethod.ToLowerInvariant())
            {
                case "pix":
                    paymentProcessor = new PixPaymentProcessor(_ctx);
                    break;
                case "creditcard":
                    paymentProcessor = new CreditCardPaymentProcessor(_ctx);
                    break;
                case "paypal":
                    paymentProcessor = new PaypalPaymentProcessor(_ctx);
                    break;
                default:
                    throw new ArgumentException("Método de pagamento não suportado", nameof(paymentMethod));
            }

            // Processa o pagamento usando o processador de pagamento selecionado
            return await paymentProcessor.ProcessoPagamento(paymentValue, customerId);
        }
    }
}
