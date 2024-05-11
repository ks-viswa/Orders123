using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreateOrder.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace CreateOrder.Controllers.Tests
{
    [TestClass()]
    public class OrderManagementControllerTests
    {
        private  OrderManagementController _orderManagementController;

        [TestMethod()]
        public void CreateOrderAsyncTest()
        {
            //IServiceCollection serviceCollection = new ServiceCollection();
            //var mockLog = new Mock<ILogger<OrderManagementController>>();
            //var mockLogFactory = new Mock<ILoggerFactory>();
            //mockLogFactory.Setup(f => f.CreateLogger<OrderManagementController>()).Returns(mockLog.o);
            //serviceCollection.AddSingleton<ILoggerFactory>(mockLogFactory.Object);

            var mockLogger = new Mock<ILogger<OrderManagementController>>();
            mockLogger.Setup(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<object>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<object, Exception, string>>()));

            var mockLoggerFactory = new Mock<ILoggerFactory>();
            mockLoggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(() => mockLogger.Object);
            _orderManagementController = new OrderManagementController(mockLoggerFactory.Object);

            _orderManagementController.CreateOrderAsync(1, "Item1", 2, 10, 20);

            Assert.Fail();
        }
    }
}