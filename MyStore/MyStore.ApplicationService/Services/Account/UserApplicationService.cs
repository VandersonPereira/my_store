using DomainNotificationHelper.Events;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Events.UserEvents;
using MyStore.Domain.Account.Repositories;
using MyStore.Domain.Account.Services;
using MyStore.Infra.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.ApplicationService.Services.Account
{
    public class UserApplicationService : ApplicationService, IUserApplicationService
    {
        private readonly IUserRepository _repository;

        public UserApplicationService(IUserRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public User Register(string email, string username, string password)
        {
            var user = new User(email, username, password);

            user.Register();

            if (Commit())
            {
                // Dispara evento de usuário registrado
                DomainEvent.Raise(new OnUserRegisteredEvent(user));

                return user;
            }

            return null;
        }
    }
}
