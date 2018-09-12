using DomainNotificationHelper;
using DomainNotificationHelper.Events;
using MyStore.Infra.Transaction;

namespace MyStore.ApplicationService.Services
{
    public class ApplicationService
    {
        private readonly IHandler<DomainNotification> _notifications;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }

        public void Rollback(string message)
        {
            DomainEvent.Raise<DomainNotification>(new DomainNotification("BusinessError", message));
            _unitOfWork.Rollback();
        }

        public void Rollback()
        {
            _unitOfWork.Rollback();
        }
    }
}
