using Inventory.Application.Commands;
using Inventory.Application.Queries;
using Inventory.Domain.Entities;
using Inventory.Domain.Repositories;
using Inventory.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Inventory.Application.Services
{
    /// <summary>
    ///  Esta clase ealiza de lanzador de Command and Querys
    /// </summary>
    public class InventoryServices
    {
        private readonly IItemRepository ItemRepository;
        private readonly ILogger<InventoryServices> _logger;

        public InventoryServices(IItemRepository itemRepository, ILogger<InventoryServices> logger)
        {
            ItemRepository = itemRepository;
            _logger = logger;
        }

        /// <summary>
        /// Lanza el comamndHandler para crear un item
        /// </summary>
        /// <param name="createItemCommand">Comando para crear un Item</param>
        public async Task CommandHandler(CreateItemCommand createItemCommand)
        {
            _logger.LogInformation("Lanzando el comando para crear un item");
            var item = new Item(ItemId.Create(Guid.NewGuid()));
            item.SetName(ItemName.Create(createItemCommand.Name));
            item.SetExpirationDate(ItemExpirationDate.Create(createItemCommand.ExpirationDate));
            item.SetType(ItemType.Create(createItemCommand.Type));
            await ItemRepository.AddItem(item);

        }

        /// <summary>
        /// Lanza el comamndHandler para eliminar un item
        /// </summary>
        /// <param name="deleteItemCommand">Comando para eliminar un Item</param>
        public async Task CommandHandler(DeleteItemCommand deleteItemCommand)
        {
            _logger.LogInformation("Lanzando el comando de eliminar item");
            await ItemRepository.DelteItem(ItemId.Create(deleteItemCommand.ItemId));

        }
        /// <summary>
        /// Lanza el QueryHandler para traer un item por su id
        /// </summary>
        /// <param name="getItemQuery">Query para encontrar un item</param>
        public async Task<Item> QueryHandler(GetItemQuery getItemQuery)
        {
            _logger.LogInformation("Lanzando la query para obtener un item");
            return await ItemRepository.GetItemById(ItemId.Create(getItemQuery.ItemId));

        }

        /// <summary>
        /// Lanza el QueryHandler para traer todos los items
        /// </summary>
        /// <param name="getAllItemQuery">Query para encontrar todos items</param>
        public async Task<List<Item>> QueryHandler(GetAllItemQuery getAllItemQuery)
        {
            _logger.LogInformation("Lanzando la query para obtener todos los item");
            return (List<Item>)await ItemRepository.GetItems();

        }
    }

}

