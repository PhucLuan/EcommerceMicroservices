using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "LuanNguyen", FirstName = "Luan", LastName = "Nguyen", EmailAddress = "luannguyen@gmail.com", AddressLine = "HoChiMinh", Country = "VietNam", TotalPrice = 350
                , ZipCode="ZipCode1232435",State="Demo State", CardName="LuanCard", CardNumber="34534654",Expiration="demo Expiration"
                , CVV = "342", PaymentMethod = 1
                ,CreatedBy = "LuanNguyen",CreatedDate = DateTime.Now,LastModifiedBy = "LuanNguyen"}
            };
        }
    }
}
