using DomainNotificationHelper;
using MyStore.ApplicationService.Services.Common;
using MyStore.Domain.Account.Events.UserEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.ApplicationService.Handlers.Account
{
    public class OnUserRegisteredHandler : IHandler<OnUserRegisteredEvent>
    {
        public void Dispose()
        {
            // Não será usado
        }

        public void Handle(OnUserRegisteredEvent args)
        {
            var user = args.User;
            var title = args.EmailTitle;
            var body = args.EmailBory.Replace("##EMAIL##", user.Email);

            EmailService.Send(user.Email, title, body);
        }

        public bool HasNotifications()
        {
            // Não será usado
            return false;
        }

        public IEnumerable<OnUserRegisteredEvent> Notify()
        {
            // Não será usado
            return null;
        }
    }
}
