using System.Collections.Generic;

namespace Core.DomainObjects;

public interface INotify
{
    bool HasNotification();
    List<NotificationMessage> GetNotifications();
    void Handler(NotificationMessage notifier);
}