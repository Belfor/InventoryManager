
using System;


namespace Inventory.Application.Commands
{
    public class CreateItemCommand
    {
        public string  Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Type { get; set; }
        public CreateItemCommand() { }
        public CreateItemCommand(string name, DateTime expirationDate, int type)
        {
            
            Name = name;
            ExpirationDate = expirationDate;
            Type = type;
        }
    }
}
