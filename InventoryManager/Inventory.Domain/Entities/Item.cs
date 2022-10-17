using Inventory.Domain.ValueObjects;
using System;

namespace Inventory.Domain.Entities
{
    public class Item
    {
        public Guid Id { get; }

        public ItemName Name { get; private set; }

        public ItemExpirationDate ExpirationDate { get; private set; }

        public ItemType Type { get; private set; }

        public Item(Guid id)
        {
            Id = id;
        }

        public void SetName(ItemName name)
        {
            Name = name;
        }
        public void SetExpirationDate(ItemExpirationDate expirationDate)
        {
            ExpirationDate = expirationDate;
        }
        public void SetType(ItemType type)
        {
            Type = type;
        }
      
    }
}
