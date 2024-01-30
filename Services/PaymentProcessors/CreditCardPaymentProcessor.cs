using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services.PaymentProcessors
{
    public class CreditCardPaymentProcessor : IPaymentProcessor
    {
        private readonly TestDbContext _ctx;
        public CreditCardPaymentProcessor(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Order> ProcessoPagamento(decimal paymentValue, int customerId)
        {
            // Neste exemplo, apenas simularemos uma transação bem-sucedida e retornaremos um objeto Order

            // Verifica se o cliente existe no banco de dados
            var customer = await _ctx.Customers.FindAsync(customerId);
            if (customer == null)
            {
                // Se o cliente não for encontrado, lança uma exceção ou retorna null, dependendo do que for apropriado
                throw new InvalidOperationException($"Cliente com ID {customerId} não encontrado.");
            }

            // Lógica simulada do processamento do pagamento via cartão de crédito
            Console.WriteLine($"Processando pagamento via cartão de crédito para o cliente ID: {customerId}, no valor de: {paymentValue}");


            // Supondo que o pagamento tenha sido processado com sucesso, criamos um objeto Order com os detalhes do pagamento
            var order = new Order
            {
                Id = customerId, 
                CustomerId = customerId,
                Value = paymentValue,
                OrderDate = DateTime.UtcNow, // Definindo a data atual como data de pagamento
                Customer = customer
            };

            // Retorna o objeto Order simulando o resultado do processamento do pagamento via cartão de crédito
            return await Task.FromResult(order);
        }
    }
}

