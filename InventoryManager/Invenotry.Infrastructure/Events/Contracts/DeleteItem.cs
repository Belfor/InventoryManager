using System;


namespace Invenotry.Infrastructure.Events.Contracts
{
    public class DeleteItem
    {
        public Guid Guid { get; set; }
        
        public DeleteItem(Guid guid)
        {
            Guid = guid;
        }
    }
}
