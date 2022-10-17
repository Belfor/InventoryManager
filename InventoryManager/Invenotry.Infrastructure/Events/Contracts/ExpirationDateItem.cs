using System;


namespace Invenotry.Infrastructure.Events.Contracts
{
    public class ExpirationDateItem
    {
        public Guid Guid { get; set; }
        public DateTime ExpirationDate {get; set; }
        
        public ExpirationDateItem(Guid guid, DateTime expirationDate)
        {
            Guid = guid;
            ExpirationDate = expirationDate;
        }
    }
}
