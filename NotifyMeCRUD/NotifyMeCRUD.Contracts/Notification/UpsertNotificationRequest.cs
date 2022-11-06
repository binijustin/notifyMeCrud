using NotifyMeCRUD.Contracts.Notification.Common;

namespace NotifyMeCRUD.Contracts.NotifyMe;

public record UpsertNotificationRequest(
    Guid Id,
    NotificationDetails NotificationDetails,
    List<string> AdditionalRequest);