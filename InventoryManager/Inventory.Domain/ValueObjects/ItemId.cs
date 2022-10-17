using System;

namespace Inventory.Domain.ValueObjects
{
    public class ItemId
    {
        public Guid Value { get; }

        internal ItemId(Guid value)
        {
            Value = value;
        }

        public static ItemId Create(Guid value)
        {
            return new ItemId(value);
        }

        public static implicit operator Guid(ItemId itemId)
        {
            return itemId.Value;
        }
    }
}
