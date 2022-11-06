namespace NotifyMeCRUD.Contracts.Notification.Common;
public record NotificationDetails(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime
);