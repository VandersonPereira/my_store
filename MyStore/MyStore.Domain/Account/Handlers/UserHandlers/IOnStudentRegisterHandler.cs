using DomainNotificationHelper;
using MyStore.Domain.Account.Events.UserEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Account.Handlers.UserHandlers
{
    public interface IOnStudentRegisterHandler : IHandler<OnUserRegisteredEvent>
    {
    }
}
