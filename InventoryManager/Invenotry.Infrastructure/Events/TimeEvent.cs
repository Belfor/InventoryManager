using Invenotry.Infrastructure.Events.Contracts;
using MassTransit;
using System;
using System.Threading.Tasks;
using System.Timers;

namespace Invenotry.Infrastructure.Events
{
    public class TimeEvent
    {
        private readonly IBusControl _busControl;
        public TimeEvent(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public async Task AddEvent(DateTime dateExpiration, Guid id)
        {
            
            Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += delegate { _ = OnTimedEventAsync(dateExpiration, id); };
            aTimer.Interval = (dateExpiration - DateTime.Now).TotalMilliseconds;
            aTimer.Enabled = true;
            aTimer.AutoReset = false;
        }

        
        private async Task OnTimedEventAsync(DateTime dateExpiration, Guid id)
        {
            await _busControl.Publish(new ExpirationDateItem(id, dateExpiration));
        }

    }
}
