using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderManagement.DataAccess;
using OrderManagement.Models;
using System.Reflection.Metadata;

namespace CreateOrder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderManagementController : ControllerBase
    {

        private readonly ILogger _logger;

        public OrderManagementController(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("OrderManagement");
        }

        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrderAsync(
            int customerId,
            string itemName,
            int quantity,
            decimal unitPrice,
            decimal total)
        {

            _logger.LogInformation("Creating order");

            var order = new Order
            {
                CustomerId = customerId
                ,
                ItemName = itemName
                ,
                Quantity = quantity
                ,
                UnitPrice = unitPrice
                ,
                Total = total
            };

            using (var context = new DataContext())
            {

                context.Orders.Add(order);
                context.SaveChanges();
            }

            return new OkObjectResult(order);
        }

        [Route("GetAllOrders")]
        public IActionResult GetAllOrders(
            int customerId)
        {

            var orders = new List<Order>();

            using (var context = new DataContext())
            {

                orders = context.Orders.Where(o => o.CustomerId == customerId).ToList();

            }

            return new OkObjectResult(orders);
        }


        [Route("GetOrder")]
        public IActionResult GetOrder(
            int orderId)
        {

            var order = new Order();

            using (var context = new DataContext())
            {

                order = context.Orders.Where(o => o.Id == orderId).FirstOrDefault();

            }

            return new OkObjectResult(order);
        }
    }

}
