using Invenotry.Infrastructure.Events;
using Invenotry.Infrastructure.Events.Contracts;
using Inventory.Domain.Entities;
using Inventory.Domain.Repositories;
using Inventory.Domain.ValueObjects;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invenotry.Infrastructure
{
    public class ItemRespository : IItemRepository
    {
        private DatabaseContext _db;
        private readonly IBusControl _busControl;
        private readonly ILogger<ItemRespository> _logger;
        private readonly TimeEvent _timeEvent;

        public ItemRespository(DatabaseContext context, IBusControl busControl, ILogger<ItemRespository> logger,TimeEvent timeEvent)
        {
            _db = context;
            _busControl = busControl;
            _logger = logger;
            _timeEvent = timeEvent;
        }
        public async Task AddItem(Item item)
        {

            await _db.AddAsync(item);
            await _db.SaveChangesAsync();
            await _timeEvent.AddEvent(item.ExpirationDate.Value, item.Id); 
            _logger.LogInformation($"El item con id {item.Id} se ha guardado en la base de datos");

        }

        public async Task DelteItem(ItemId id)
        {
            var item = await GetItemById(id);
            _db.Attach(item);
            _db.Remove(item);
            await _db.SaveChangesAsync();
            await _busControl.Publish(new DeleteItem(id));
            _logger.LogInformation($"El item con id {item.Id} se ha eliminado en la base de datos");
        }

        public async Task<Item> GetItemById(ItemId id)
        {
            _logger.LogInformation($"Obteniendo el item con id {id.Value} de la base de datos");
            return await _db.Items.FindAsync((Guid)id);
        }

        public async Task<IList<Item>> GetItems()
        {
            _logger.LogInformation($"Obteniendo todos los items de la base de datos");
            return _db.Items.Select(x => x).ToList();
        }
    }
}
