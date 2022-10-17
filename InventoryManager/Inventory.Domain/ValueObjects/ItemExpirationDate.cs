using System;


namespace Inventory.Domain.ValueObjects
{
    public class ItemExpirationDate
    {
        public DateTime Value { get; }

        internal ItemExpirationDate(DateTime value)
        {
            Value = value;
        }

        public static ItemExpirationDate Create(DateTime value)
        {
            return new ItemExpirationDate(value);
        }
    }
}
