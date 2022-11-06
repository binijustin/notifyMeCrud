using NotifyMeCRUD.Contracts.Notification.Common;

namespace NotifyMeCRUD.Contracts.NotifyMe;

public record CreateNotificationRequest(
    NotificationDetails NotificationDetails,
    List<string> AdditionalRequest);