
using System;

namespace Inventory.Application.Commands
{
    public class DeleteItemCommand
    {
        public Guid ItemId { get; }

        public DeleteItemCommand(Guid itemId)
        {
            ItemId = itemId;
           
        }
    }

}
