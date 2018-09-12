using DomainNotificationHelper.Events.Contracts;
using MyStore.Domain.Account.Entities;
using MyStore.SharedKernel.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Account.Events.UserEvents
{
    public class OnUserRegisteredEvent : IDomainEvent
    {
        public OnUserRegisteredEvent(User user)
        {
            Date = DateTime.Now;
            User = user;
            EmailTitle = EmailTemplates.WelcomeEmailTitle;
            EmailBory = EmailTemplates.WelcomeEmailBody;
        }

        public User User { get; private set; }
        public string EmailTitle { get; private set; }
        public string EmailBory { get; private set; }
        public DateTime Date { get; set; }
    }
}
