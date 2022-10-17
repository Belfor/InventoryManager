
namespace Inventory.Domain.ValueObjects
{
    public class ItemName
    {
        public string Value { get; }

        internal ItemName (string value)
        {
            Value = value;
        }

        public static ItemName Create(string value)
        {
            return new ItemName(value);
        }
    }
}
