using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data;

public class OrderContextSeed
{
    public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
    {
        if (!orderContext.Orders.Any())
        {
            orderContext.Orders.AddRange(GetOrders());
            await orderContext.SaveChangesAsync();
            logger.LogInformation($"Ordering Database: {typeof(OrderContext).Name} seeded.");
        }
    }

    private static IEnumerable<Order> GetOrders()
    {
        return new List<Order>
        {
            new()
            {
                UserName = "James",
                FirstName = "James",
                LastName = "Ibori",
                EmailAddress = "JamesIbori@eshop.net",
                AddressLine = "Ojodu",
                Country = "Nigeria",
                TotalPrice = 450,
                State = "LAG",
                ZipCode = "900009",

                CardName = "Visa",
                CardNumber = "1234567890123456",
                CreatedBy = "Ibori",
                Expiration = "12/25",
                Cvv = "123",
                PaymentMethod = 1,
                LastModifiedBy = "Ibori",
                LastModifiedDate = new DateTime(),
            }
        };
    }
}