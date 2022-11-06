namespace NotifyMeCRUD.Contracts.NotifyMe;

public record NotificationResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime,
    List<string> AdditionalRequest);