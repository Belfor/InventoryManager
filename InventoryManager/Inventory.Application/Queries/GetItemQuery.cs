using System;

namespace Inventory.Application.Queries
{
    public class GetItemQuery
    {
        public Guid ItemId { get; }

        public GetItemQuery(Guid itemId)
        {
            ItemId = itemId;

        }
    }
}
