using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventory.Application.Services;
using Moq;
using Inventory.Domain.Repositories;
using Inventory.Application.Commands;
using System;
using Inventory.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Inventory.Domain.ValueObjects;
using Inventory.Application.Queries;
using FluentAssertions;
using System.Collections.Generic;

namespace Inventory.Application.Services.Tests
{
    [TestClass()]
    public class InventoryServicesTests
    {
            
        private static Mock<IItemRepository> _itemRepositoryMock;
        private static ILogger _logger;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _itemRepositoryMock = new Mock<IItemRepository>();
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            _logger = loggerFactory.CreateLogger<InventoryServices>();

        }
        [TestMethod()]
        public void CommandHandlerCreateItemTest()
        {
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            _logger = loggerFactory.CreateLogger<InventoryServices>();
            _itemRepositoryMock.Setup(repo => repo.AddItem(It.IsAny<Item>())).Returns(Task.CompletedTask);
            var inventoryService = new InventoryServices(_itemRepositoryMock.Object, (ILogger<InventoryServices>)_logger);
            var task = inventoryService.CommandHandler(new CreateItemCommand("Item1",DateTime.Now, 1));
            if (task.IsCompletedSuccessfully)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod()]
        public void CommandHandlerDeleteItemTest()
        {
          
            _itemRepositoryMock.Setup(repo => repo.DelteItem(It.IsAny<ItemId>())).Returns(Task.CompletedTask);
            var inventoryService = new InventoryServices(_itemRepositoryMock.Object, (ILogger<InventoryServices>)_logger);
            var task = inventoryService.CommandHandler(new DeleteItemCommand(Guid.NewGuid()));
            if (task.IsCompletedSuccessfully)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void QueryHandlerGetItemTest()
        {
            var item = new Item(ItemId.Create(Guid.NewGuid()));
            item.SetName(ItemName.Create("Item"));
            item.SetExpirationDate(ItemExpirationDate.Create(DateTime.Now));
            item.SetType(ItemType.Create(1));
            _itemRepositoryMock.Setup(repo => repo.GetItemById(It.IsAny<ItemId>())).ReturnsAsync(item);
            var inventoryService = new InventoryServices(_itemRepositoryMock.Object, (ILogger<InventoryServices>)_logger);
            var result = inventoryService.QueryHandler(new GetItemQuery(Guid.NewGuid())).Result;

            result.Name.Value.Should().BeEquivalentTo(item.Name.Value);
           
          
        }

        [TestMethod()]
        public void QueryHandlerGetAllItemTest()
        {
            var item = new Item(ItemId.Create(Guid.NewGuid()));
            item.SetName(ItemName.Create("Item"));
            item.SetExpirationDate(ItemExpirationDate.Create(DateTime.Now));
            item.SetType(ItemType.Create(1));

            var item2 = new Item(ItemId.Create(Guid.NewGuid()));
            item2.SetName(ItemName.Create("Item2"));
            item2.SetExpirationDate(ItemExpirationDate.Create(DateTime.Now));
            item2.SetType(ItemType.Create(2));

            var items = new List<Item> { item, item2 };
            _itemRepositoryMock.Setup(repo => repo.GetItems()).ReturnsAsync(items);

            var inventoryService = new InventoryServices(_itemRepositoryMock.Object, (ILogger<InventoryServices>)_logger);
            var result = inventoryService.QueryHandler(new GetAllItemQuery()).Result;

            result.ToArray()[0].Name.Value.Should().BeEquivalentTo(item.Name.Value);
            result.ToArray()[1].Name.Value.Should().BeEquivalentTo(item2.Name.Value);

        }
    }
}