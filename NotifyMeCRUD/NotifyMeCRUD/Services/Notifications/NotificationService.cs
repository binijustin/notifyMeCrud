using ErrorOr;
using NotifyMeCRUD.ServiceErrors;
using NotifyMeCRUD.Models;

namespace NotifyMeCRUD.Services.Notifications;

public class NotificationService : INotificationService
{
    private static readonly Dictionary<Guid, Notification> _notifications = new();
    public ErrorOr<Created> CreateNotification(Notification request)
    {
       _notifications.Add(request.Id, request);
       return Result.Created;
    }

    public ErrorOr<Notification> GetNotification(Guid id)
    {
        if(_notifications.TryGetValue(id, out var notification))
            return notification;
        else
            return Errors.Notification.NotFound;
    }

    public ErrorOr<UpsertedNotification> UpsertNotification(Notification request)
    {
        var isNewlyCreated = !_notifications.ContainsKey(request.Id);
       _notifications[request.Id] = request;
       return new UpsertedNotification(isNewlyCreated);
    }

    public ErrorOr<Deleted> DeleteNotification(Guid id)
    {
       _notifications.Remove(id);
       return Result.Deleted;
    }

}