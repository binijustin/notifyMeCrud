using ErrorOr;
using NotifyMeCRUD.Models;

namespace NotifyMeCRUD.Services.Notifications;

public interface INotificationService{
    ErrorOr<Created> CreateNotification(Notification request);
    ErrorOr<Notification> GetNotification(Guid id);
    ErrorOr<UpsertedNotification> UpsertNotification(Notification request);
    ErrorOr<Deleted> DeleteNotification(Guid id);
}