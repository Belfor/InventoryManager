
using Type = Inventory.Domain.Common.Type; 

namespace Inventory.Domain.ValueObjects
{
    public class ItemType
    {
        public Type Value { get; }

        internal ItemType(Type value)
        {
            Value = value;
        }

        public static ItemType Create(Type value)
        {
            return new ItemType(value);
        }
        public static ItemType Create(int value)
        {
            var type = (Type)value;
            return new ItemType(type);
        }
    }
}

